using MMS.DataManager.BasicManagement.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.DingTalk
{
    public interface IDingTalkAppService :IApplicationService
    {

        Task<LoginOutput> DingTalkLoginAsync(string code);

        /// <summary>
        /// 导入钉钉的组织架构
        /// </summary>
        /// <returns></returns>
        Task<ApiResultDto> LoadDingTalkOrganizationToSystem();
    }
}
