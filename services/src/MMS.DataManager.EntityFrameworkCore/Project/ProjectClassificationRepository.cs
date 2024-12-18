using MMS.DataManager.EntityFrameworkCore;
using MMS.DataManager.Project.AggregateRoot;
using MMS.DataManager.Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace MMS.DataManager.Project
{
    public class ProjectClassificationRepository : EfCoreRepository<DataManagerDbContext, ProjectClassification, Guid>, IProjectClassificationRepository
    {
        public ProjectClassificationRepository(IDbContextProvider<DataManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<ProjectClassification>> GetRootTreeByOrganizationId(Guid organizationId, bool include = true)
        {
            var roots = await (await GetDbSetAsync())
               .IncludeProjectClassificationTreeDetails(include)
               .Where(x => x.ParentId == null && x.OrganizationId.Equals(organizationId))
               .OrderBy(x => x.Code)
               .ToListAsync();

            foreach (var item in roots)
            {
                await GetNodeFullLevel(item, include);
            }
            return roots;
        }

        public async Task<int> GetSameParentTotalCount(Guid id)
        {
            var find = await (await GetDbSetAsync())
            .IncludeProjectClassificationTreeDetails()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (find == null)
            {
                return 999;
            }
            if(find.Children.Count== 0)
            {
                return 0;
            }

            return find.Children.Max(x => x.Code);
        }

        public async Task<ProjectClassification> InsertRootNode(Guid organizationId, Guid? parentId, string name, int code)
        {
            var node = new ProjectClassification()
            {
                OrganizationId = organizationId,
                ParentId = parentId,
                Name = name,
                Code = code
            };
            return await base.InsertAsync(node, autoSave: true);
        }


        async Task GetNodeFullLevel(ProjectClassification node, bool include)
        {
            if (node.Children == null || node.Children.Count == 0)
            {
                node.Children = await (await GetDbSetAsync())
                    .IncludeProjectClassificationTreeDetails(include)
                    .Where(x => x.ParentId == node.Id)
                    .OrderBy(x => x.Code)
                    .ToListAsync();
            }
            else
            {
                node.Children = node.Children.OrderBy(x => x.Code).ToList();
            }

            foreach (var item in node.Children)
            {
                await GetNodeFullLevel(item, include);
            }
        }
    }
}
