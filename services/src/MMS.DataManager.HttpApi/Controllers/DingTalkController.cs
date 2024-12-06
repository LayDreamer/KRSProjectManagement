using MMS.DataManager.BasicManagement.Users.Dtos;
using MMS.DataManager.DingTalk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Controllers
{
    [Route("DingTalk")]
    public class DingTalkController : DataManagerController, IDingTalkAppService
    {
        private readonly IDingTalkAppService _service;

        public DingTalkController(IDingTalkAppService service)
        {
            _service = service;
        }


        [HttpPost("DingTalkLogin")]
        public async Task<LoginOutput> DingTalkLoginAsync(string code)
        {
            return await _service.DingTalkLoginAsync(code);
        }


        [HttpPost("LoadOrganization")]
        public async Task<ApiResultDto> LoadDingTalkOrganizationToSystem()
        {
            return await _service.LoadDingTalkOrganizationToSystem();
        }
    }
}
