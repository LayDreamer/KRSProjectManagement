using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MMS.DataManager.BasicManagement.ConfigurationOptions;
using MMS.DataManager.BasicManagement.DingTalk;
using MMS.DataManager.BasicManagement.OrganizationUnits;
using MMS.DataManager.BasicManagement.Users;
using MMS.DataManager.BasicManagement.Users.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Caching;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using MMS.DataManager.DingTalk.Dto;
using MMS.DataManager.BasicManagement.OrganizationUnits.Dto;
using static Volo.Abp.Identity.IdentityPermissions;
using static FreeSql.Internal.GlobalFilter;
using YamlDotNet.Core;

namespace MMS.DataManager.DingTalk
{
    public class DingTalkAppService : DataManagerAppService, IDingTalkAppService
    {
        private const string _appId = "dingfuqtbcp3bgpni3ay";
        private const string _appSecret = "o7TLszXUPMZZvuXL4V4ggxlx-Fpb8qTUb95mEEEtEPrpUw_1FE3lZF8wdb_9MjMR";
        private const string _redirectUrl = "https://localhost:4200/login";

        private readonly OrganizationUnitManager organizationUnitManager;
        private readonly IdentityUserManager userManager;
        private readonly IdentitySecurityLogManager _identitySecurityLogManager;
        private readonly JwtOptions _jwtOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected IOptions<IdentityOptions> IdentityOptions { get; }


        private readonly string _appTokenCacheKey = "B36BA112-A119-25AA-42D5-C44EAF47AF83";
        private readonly IDistributedCache<string> _appTokenCache;


        public DingTalkAppService(
            IHttpContextAccessor httpContextAccessor,
            IOptionsSnapshot<JwtOptions> jwtOptions,
            OrganizationUnitManager organizationUnitManager,
            IdentityUserManager userManager,
            IdentitySecurityLogManager identitySecurityLogManager,
            IDistributedCache<string> appTokenCache,
            IOptions<IdentityOptions> identityOptions)
        {
            this.organizationUnitManager = organizationUnitManager;
            this.userManager = userManager;
            _identitySecurityLogManager = identitySecurityLogManager;
            _appTokenCache = appTokenCache;
            _jwtOptions = jwtOptions.Value;
            _httpContextAccessor = httpContextAccessor;
            IdentityOptions = identityOptions;
        }


        public async Task<ApiResultDto> LoadDingTalkOrganizationToSystem()
        {
            var result = new ApiResultDto
            {
                Success = true
            };
            try
            {
                var token = await GetDingAppTalkTokenByCache();
                var client = new HttpClient();
                var url = $"https://oapi.dingtalk.com/topapi/v2/department/listsub?access_token={token}";
                var response = await client.PostAsync(url, null);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var dto = JsonConvert.DeserializeObject<DingTalkOrganizationResult>(responseContent);
                    if (dto.ErrorMsg != "ok")
                    {
                        result.Error = "Post Failed";
                        result.Success = false;
                        return result;
                    }
                    foreach (var item in dto.Result)
                    {
                        var create = new Volo.Abp.Identity.OrganizationUnit(Guid.NewGuid(), item.Name);
                        create.SetProperty("DingTalkOrganizationUnitId", item.DepId);
                        await organizationUnitManager.CreateAsync(create);
                        await BuildOrganization(create, token);
                    }
                }
            }
            catch (Exception e)
            {
                result.Error = e.Message;
                result.Success = false;
            }
            return result;
        }

        public async Task<LoginOutput> DingTalkLoginAsync(string code)
        {
            var token = await GetDingAppTalkTokenByCache();
            var client = new HttpClient();
            {
                var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                var signature = GenerateSignature(timestamp, _appSecret);
                var snsUrl =
                    $"https://oapi.dingtalk.com/sns/getuserinfo_bycode?accessKey={_appId}&timestamp={timestamp}&signature={signature}";
                var jsonContent = JsonConvert.SerializeObject(new { tmp_auth_code = code });
                var content = new StringContent(jsonContent);
                var response = await client.PostAsync(snsUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var dto = JsonConvert.DeserializeObject<DingTalkGetUserApiResultDto>(responseContent);
                    if (dto.ErrorMsg == "ok")
                    {
                        var name = dto.UserInfo.NickName;
                        await IdentityOptions.SetAsync();
                        var unionId = dto.UserInfo.UnionId;
                        var url = $"https://oapi.dingtalk.com/user/getUseridByUnionid?access_token={token}&unionid={dto.UserInfo.UnionId}";
                        response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            responseContent = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<DingTalkGetUserApi1ResultDto>(responseContent);
                            if (result.ErrorMsg == "ok")
                            {
                                var userId = result.UserId;
                                var user = await userManager.FindByNameAsync(name);
                                if (user != null)
                                {
                                    await _identitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
                                    {
                                        Action = _httpContextAccessor.HttpContext?.Request.Path,
                                        UserName = user.Name,
                                        Identity = "Bearer"
                                    });
                                    return await BuildResult(user);
                                }
                                else
                                {
                                    //拿到用户详细信息
                                    url = $"https://oapi.dingtalk.com/user/get?access_token={token}&userid={userId}";
                                    response = await client.GetAsync(url);
                                    if (response.IsSuccessStatusCode)
                                    {
                                        responseContent = await response.Content.ReadAsStringAsync();

                                        //TODO 用户详细详细存取部分到数据库

                                        var id = GuidGenerator.Create();
                                        var addUser = new IdentityUser(id, userId, userId + "@qq.com", CurrentTenant.Id);
                                        addUser.Name = name;
                                        addUser.SetProperty("DingTalkUserId", userId);
                                        string password = "1q2w3E*";
                                        await userManager.CreateAsync(addUser, password);

                                        user = await userManager.FindByNameAsync(userId);
                                        await userManager.SetRolesAsync(user, ["admin"]);

                                        var findUser = await userManager.FindByNameAsync(userId);
                                        await _identitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
                                        {
                                            Action = _httpContextAccessor.HttpContext?.Request.Path,
                                            UserName = findUser.Name,
                                            Identity = "Bearer"
                                        });
                                        return await BuildResult(findUser);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        private async Task<string> GetDingAppTalkTokenByCache()
        {
            return await _appTokenCache.GetOrAddAsync(_appTokenCacheKey, async () =>
            {
                var client = new HttpClient();
                var url = $"https://oapi.dingtalk.com/gettoken?appkey={_appId}&appsecret={_appSecret}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        var accessToken = doc.RootElement.GetProperty("access_token").GetString();
                        return accessToken;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }, () => new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
            });
        }

        private async Task BuildOrganization(OrganizationUnit parent, string token)
        {
            var parentId = parent.GetProperty("DingTalkOrganizationUnitId");
            var client = new HttpClient();
            var url = $"https://oapi.dingtalk.com/topapi/user/listsimple?access_token={token}";
            var jsonContent = JsonConvert.SerializeObject(new { dept_id = parentId, cursor = 0, size = 100 });
            var content = new StringContent(jsonContent);
            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<DingTalkOrganizationUserResult>(responseContent);
                if (dto.ErrorMsg == "ok")
                {
                    foreach (var item in dto.Result.Lists)
                    {
                        var user = new IdentityUser(Guid.NewGuid(), item.Id.ToString(), item.Id + "@qq.ocm");
                        user.Name = item.Name;
                        //TODO 设置用户角色
                        user.SetProperty("DingTalkUserId", item.Id);
                        var result = await userManager.CreateAsync(user, "1q2w3E*");
                        if (result.Succeeded)
                        {
                            user = await userManager.FindByNameAsync(item.Id.ToString());
                            await userManager.SetRolesAsync(user, ["admin"]);
                            await userManager.AddToOrganizationUnitAsync(user.Id, parent.Id);
                        }
                    }
                }
            }
            url = $"https://oapi.dingtalk.com/topapi/v2/department/listsub?access_token={token}";
            jsonContent = JsonConvert.SerializeObject(new { dept_id = parentId });
            content = new StringContent(jsonContent);
            response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<DingTalkOrganizationResult>(responseContent);
                if (dto.Result == null || dto.Result.Count == 0) { return; }
                foreach (var item in dto.Result)
                {
                    var create = new Volo.Abp.Identity.OrganizationUnit(Guid.NewGuid(), item.Name, parent.Id);
                    create.SetProperty("DingTalkOrganizationUnitId", item.DepId);
                    await organizationUnitManager.CreateAsync(create);
                    await BuildOrganization(create, token);
                }
            }
        }


        private string GenerateSignature(string timestamp, string appSecret)
        {

            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(appSecret)))
            {
                byte[] signatureBytes = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(timestamp));
                string signature = Convert.ToBase64String(signatureBytes);
                if (string.IsNullOrEmpty(signature))
                {
                    return string.Empty;
                }
                string urlEncodedSignature = HttpUtility.UrlEncode(signature, Encoding.UTF8)
                    .Replace("+", "%20")
                    .Replace("*", "%2A")
                    .Replace("~", "%7E")
                    .Replace("/", "%2F");
                return urlEncodedSignature;
            }
        }

        private async Task<LoginOutput> BuildResult(IdentityUser user)
        {
            if (!user.IsActive) throw new BusinessException(BasicManagementErrorCodes.UserLockedOut);
            var roles = await userManager.GetRolesAsync(user);
            if (roles == null || roles.Count == 0)
            {
            }
            var token = GenerateJwt(user.Id, user.UserName, user.Name, user.Email,
                user.TenantId.ToString(), roles.ToList());
            var loginOutput = ObjectMapper.Map<IdentityUser, LoginOutput>(user);
            loginOutput.Token = token;
            loginOutput.Roles = roles.ToList();
            return loginOutput;
        }

        /// <summary>
        /// 生成jwt token
        /// </summary>
        /// <returns></returns>
        private string GenerateJwt(Guid userId, string userName, string name, string email, string tenantId, List<string> roles)
        {
            var dateNow = Clock.Now;
            var expirationTime = dateNow.AddHours(_jwtOptions.ExpirationTime);
            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecurityKey);

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Audience, _jwtOptions.Audience),
                new Claim(JwtClaimTypes.Issuer, _jwtOptions.Issuer),
                new Claim(AbpClaimTypes.UserId, userId.ToString()),
                new Claim(AbpClaimTypes.Name, name),
                new Claim(AbpClaimTypes.UserName, userName),
                new Claim(AbpClaimTypes.Email, email),
                new Claim(AbpClaimTypes.TenantId, tenantId)
            };

            foreach (var item in roles)
            {
                claims.Add(new Claim(AbpClaimTypes.Role, item));
            }

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expirationTime, // token 过期时间
                NotBefore = dateNow, // token 签发时间
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
