using MMS.DataManager.Project.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MMS.DataManager.Project.Repository
{
    public interface IProjectClassificationRepository : IBasicRepository<ProjectClassification, Guid>
    {
        Task<ProjectClassification> InsertRootNode(Guid organizationId, Guid? parentId, string name, int code);

        Task<List<ProjectClassification>> GetRootTreeByOrganizationId(Guid organizationId, bool include = true);

        Task<int> GetSameParentTotalCount(Guid id);
    }
}
