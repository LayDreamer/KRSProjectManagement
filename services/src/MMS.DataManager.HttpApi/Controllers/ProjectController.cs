using MMS.DataManager.Project;
using MMS.DataManager.Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Controllers
{
    [Route("Project")]
    public class ProjectController : DataManagerController, IProjectAppService
    {
        private readonly IProjectAppService service;

        public ProjectController(IProjectAppService service)
        {
            this.service = service;
        }

        [HttpPost("CreateProjectClassificationNode")]
        public async Task<ProjectClassificationDto> CreateProjectClassificationNode(ProjectClassificationCreateDto dto)
        {
            return await this.service.CreateProjectClassificationNode(dto);
        }

        [HttpPost("UpdateProjectClassificationNodeName")]
        public async Task<ProjectClassificationDto> UpdateProjectClassificationNodeName(ProjectClassificationUpdateDto dto)
        {
            return await this.service.UpdateProjectClassificationNodeName(dto);
        }

        [HttpPost("GetProjectClassificationNodeByOrganizationId")]
        public async Task<List<ProjectClassificationDto>> GetProjectClassificationNodeByOrganizationId(Guid id)
        {
            return await this.service.GetProjectClassificationNodeByOrganizationId(id);
        }

        [HttpPost("CreateProjectTemplate")]
        public async Task<ProjectTemplateDto> CreateProjectTemplate(ProjectTemplateCreateDto dto)
        {
            return await this.service.CreateProjectTemplate(dto);
        }

        [HttpPost("UpdateProjectTemplate")]
        public async Task<ProjectTemplateDto> UpdateProjectTemplate(ProjectTemplateUpdateDto dto)
        {
            return await this.service.UpdateProjectTemplate(dto);
        }

        [HttpPost("GetAllProjectTemplates")]
        public async Task<List<ProjectTemplateDto>> GetAllProjectTemplates()
        {
            return await this.service.GetAllProjectTemplates();
        }
    }
}
