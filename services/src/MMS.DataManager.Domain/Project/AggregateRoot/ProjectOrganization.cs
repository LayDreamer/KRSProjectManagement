using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MMS.DataManager.Project.AggregateRoot
{
    public class ProjectOrganization : BasicAggregateRoot<Guid>
    {
        public Guid ProjectID { get; set; }

        public ProjectInfo ProjectInfo { get; set; }

        public Guid OrganizationId { get; set; }

        public OrganizationUnit Organization { get; set; }

        public ProjectOrganizationRole Role { get; set; }
    }
}
