using MMS.DataManager.Project.AggregateRoot;
using MMS.DataManager.Project.Dto;
using MMS.DataManager.Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MMS.DataManager.Project.Manager
{
    public class ProjectInfoManager : DataManagerDomainService
    {
        private readonly IProjectClassificationRepository projectClassificationRepository;
        private readonly IBasicRepository<ProjectTemplate, Guid> projectTemplateRepository;


        public ProjectInfoManager(IProjectClassificationRepository projectClassificationRepository, IBasicRepository<ProjectTemplate, Guid> projectTemplateRepository)
        {
            this.projectClassificationRepository = projectClassificationRepository;
            this.projectTemplateRepository = projectTemplateRepository;
        }

        public async Task<ProjectClassificationDto> Insert(Guid organizationId, Guid? parentId, string name)
        {
            int code = 0;
            if (parentId != null)
            {
                var count = await projectClassificationRepository.GetSameParentTotalCount(parentId.Value);
                code = count + 1;
            }
            var entity = await projectClassificationRepository.InsertRootNode(organizationId, parentId, name, code);
            return ObjectMapper.Map<ProjectClassification, ProjectClassificationDto>(entity);
        }

        public async Task<ProjectClassificationDto> UpdateById(Guid id, string name)
        {
            var find = await projectClassificationRepository.FindAsync(id);
            if (find == null)
            {
                throw new Exception("Not Find The ProjectClassification");
            }
            find.Name = name;
            var entity = await projectClassificationRepository.UpdateAsync(find, true);
            return ObjectMapper.Map<ProjectClassification, ProjectClassificationDto>(entity);
        }


        public async Task<List<ProjectClassificationDto>> GetRootByOrganizationId(Guid organizationId)
        {
            var roots = await projectClassificationRepository.GetRootTreeByOrganizationId(organizationId);

            return ObjectMapper.Map<List<ProjectClassification>, List<ProjectClassificationDto>>(roots);
        }


        public async Task<ProjectTemplateDto> CreateProjectTemplate(string name, string description, ProjectTemplateData data, string createUser)
        {
            var projectTemplate = new ProjectTemplate()
            {
                Name = name,
                Description = description,
                Data = data,
                CreateUser = createUser
            };
            var template = await projectTemplateRepository.InsertAsync(projectTemplate, true);
            return ObjectMapper.Map<ProjectTemplate, ProjectTemplateDto>(template);
        }


        public async Task<ProjectTemplateDto> UpdateProjectTemplate(Guid id, string name, string description, ProjectTemplateData data, string updateUser)
        {
            var entity = await projectTemplateRepository.FindAsync(id);
            entity.Name = name;
            entity.Description = description;   
            entity.Data = data;
            entity.ModifyUser = updateUser;
            entity = await projectTemplateRepository.UpdateAsync(entity);
            return ObjectMapper.Map<ProjectTemplate, ProjectTemplateDto>(entity);
        }


        public async Task<List<ProjectTemplateDto>> GetAllProjectTemplates()
        {
            var list = await projectTemplateRepository.GetListAsync();
            return ObjectMapper.Map<List<ProjectTemplate>, List<ProjectTemplateDto>>(list);
        }
    }
}
