using MMS.DataManager.Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project.Manager
{
    public class ProjectInfoManager : DataManagerDomainService
    {
        private readonly IProjectTemplateRepository _projectTemplateRepository;
        private readonly IProjectTemplateFieldRepository _projectTemplateFieldRepository;
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IProjectFieldValueRepository _projectFieldValueRepository;

        public ProjectInfoManager(
            IProjectTemplateRepository projectTemplateRepository,
            IProjectTemplateFieldRepository projectTemplateFieldRepository,
            IProjectInfoRepository projectInfoRepository,
            IProjectFieldValueRepository projectFieldValueRepository)
        {
            _projectTemplateRepository = projectTemplateRepository;
            _projectTemplateFieldRepository = projectTemplateFieldRepository;
            _projectInfoRepository = projectInfoRepository;
            _projectFieldValueRepository = projectFieldValueRepository;
        }



    }
}
