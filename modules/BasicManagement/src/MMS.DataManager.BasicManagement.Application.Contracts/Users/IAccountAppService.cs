using MMS.DataManager.BasicManagement.Users.Dtos;

namespace MMS.DataManager.BasicManagement.Users
{
    public interface IAccountAppService: IApplicationService
    {
        /// <summary>
        /// 用户名密码登录
        /// </summary>
        Task<LoginOutput> LoginAsync(LoginInput input);
    }
}
