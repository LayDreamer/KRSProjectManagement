using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MMS.DataManager.Project.AggregateRoot
{
    public class ProjectUser : BasicAggregateRoot<Guid>
    {
        public Guid ProjectID { get; set; }

        public ProjectInfo ProjectInfo { get; set; }

        public Guid UserId { get; set; }

        public IdentityUser User { get; set; }

        public ProjectRole Role { get; set; }
    }
}
