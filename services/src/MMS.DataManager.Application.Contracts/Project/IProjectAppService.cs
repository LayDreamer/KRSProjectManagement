using MMS.DataManager.Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project
{
    public interface IProjectAppService : IApplicationService
    {
        Task<ProjectClassificationDto> CreateProjectClassificationNode(ProjectClassificationCreateDto dto);

        Task<ProjectClassificationDto> UpdateProjectClassificationNodeName(ProjectClassificationUpdateDto dto);

        Task<List<ProjectClassificationDto>> GetProjectClassificationNodeByOrganizationId(Guid id);

        Task<ProjectTemplateDto> CreateProjectTemplate(ProjectTemplateCreateDto dto);

        Task<ProjectTemplateDto> UpdateProjectTemplate(ProjectTemplateUpdateDto dto);

        Task<List<ProjectTemplateDto>> GetAllProjectTemplates();
    }
}
