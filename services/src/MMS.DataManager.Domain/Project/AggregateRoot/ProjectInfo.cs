using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace MMS.DataManager.Project.AggregateRoot
{
    public class ProjectInfo : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public ProjectLevel Level { get; set; }

        public Guid TemplateId { get; set; }

        public ProjectTemplate Template { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectReport Report { get; set; }

        public string DingTalkGroup {  get; set; }

        public Guid ClassificationId {  get; set; }

        public ProjectClassification Classification { get; set; }

        public string Description { get; set; }

        public string ProgressReport {  get; set; }

        public virtual List<ProjectUser> ProjectUsers { get; set; }

        public virtual List<ProjectOrganization> ProjectOrganizations { get; set; }


        public ProjectInfo()
        {
            ProjectUsers = new List<ProjectUser>();
            ProjectOrganizations = new List<ProjectOrganization>();
        }
    }
}
