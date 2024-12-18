using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MMS.DataManager.Project.AggregateRoot
{
    public class ProjectClassification : FullAuditedAggregateRoot<Guid>
    {
        public Guid OrganizationId { get; set; }
        public OrganizationUnit Organization { get; set; }

        public Guid? ParentId { get; set; }
        public ProjectClassification Parent { get; set; }

        public List<ProjectClassification> Children { get; set; }

        public string Name {  get; set; }
        public int Code { get; set; }
    }
}
