using MMS.DataManager.Project.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project
{
    public static class ProjectClassificationQueryableExtensions
    {
        public static IQueryable<ProjectClassification> IncludeProjectClassificationTreeDetails(this IQueryable<ProjectClassification> queryable, bool include = true)
        {
            return !include ? queryable : queryable.Include(x => x.Children);
        }
    }
}
