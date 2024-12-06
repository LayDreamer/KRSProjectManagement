using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.BasicManagement.DingTalk
{
    [JsonObject]
    public class DingTalkGetUserApiResultDto
    {
        [JsonProperty("errcode")]
        public int ErrorCode {  get; set; }
        
        [JsonProperty("errmsg")]
        public string ErrorMsg { get; set; }

        [JsonProperty("user_info")]
        public DingTalkUserInfoDto UserInfo { get; set; }
    }
    [JsonObject]
    public class DingTalkUserInfoDto
    {
        [JsonProperty("nick")]
        public string NickName { get; set; }

        [JsonProperty("unionid")]
        public string UnionId { get; set; }

        [JsonProperty("openid")]
        public string OpenId {  get; set; }

        [JsonProperty("main_org_auth_high_level")]
        public bool AuthHighLevel {  get; set; }
    }


    [JsonObject]
    public class DingTalkGetUserApi1ResultDto
    {
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 0 内部员工  1外部员工
        /// </summary>
        [JsonProperty("contactType")]
        public int ContactType { get; set; }

        [JsonProperty("userid")]
        public string UserId {  get; set; } 
    }
}
