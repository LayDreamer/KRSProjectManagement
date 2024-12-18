using MMS.DataManager.Project.Dto;
using MMS.DataManager.Project.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Users;

namespace MMS.DataManager.Project
{
    public class ProjectAppService : DataManagerAppService, IProjectAppService
    {
        private readonly ProjectInfoManager projectInfoManager;
        private readonly ICurrentUser currentUser;
        public ProjectAppService(ProjectInfoManager projectInfoManager, ICurrentUser currentUser)
        {
            this.projectInfoManager = projectInfoManager;
            this.currentUser = currentUser;
        }


        public async Task<ProjectClassificationDto> CreateProjectClassificationNode(ProjectClassificationCreateDto dto)
        {
            if (currentUser.Id == null)
            {
                throw new BusinessException("MMS.DataManager:LoginOver");
            }
            return await projectInfoManager.Insert(dto.OrganizationId, dto.ParentId, dto.Name);
        }

        public async Task<ProjectClassificationDto> UpdateProjectClassificationNodeName(ProjectClassificationUpdateDto dto)
        {
            if (currentUser.Id == null)
            {
                throw new BusinessException("MMS.DataManager:LoginOver");
            }
            return await projectInfoManager.UpdateById(dto.Id, dto.Name);
        }

        public async Task<List<ProjectClassificationDto>> GetProjectClassificationNodeByOrganizationId(Guid id)
        {
            if (currentUser.Id == null)
            {
                throw new BusinessException("MMS.DataManager:LoginOver");
            }
            return await projectInfoManager.GetRootByOrganizationId(id);
        }

        public async Task<ProjectTemplateDto> CreateProjectTemplate(ProjectTemplateCreateDto dto)
        {
            if (currentUser.Id == null)
            {
                throw new BusinessException("MMS.DataManager:LoginOver");
            }

            return await projectInfoManager.CreateProjectTemplate(dto.Name, dto.Description, dto.Data, currentUser.UserName);
        }

        public async Task<ProjectTemplateDto> UpdateProjectTemplate(ProjectTemplateUpdateDto dto)
        {
            if (currentUser.Id == null)
            {
                throw new BusinessException("MMS.DataManager:LoginOver");
            }
            return await projectInfoManager.UpdateProjectTemplate(dto.Id, dto.Name, dto.Description, dto.Data, currentUser.UserName);
        }

        public async Task<List<ProjectTemplateDto>> GetAllProjectTemplates()
        {
            if (currentUser.Id == null)
            {
                throw new BusinessException("MMS.DataManager:LoginOver");
            }

            return await projectInfoManager.GetAllProjectTemplates();
        }
    }
}
