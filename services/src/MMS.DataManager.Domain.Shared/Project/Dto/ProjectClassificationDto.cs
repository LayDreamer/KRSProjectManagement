using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace MMS.DataManager.Project.Dto
{
    public class ProjectClassificationDto
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? ParentId { get; set; }
        public ProjectClassificationDto Parent { get; set; }
        public List<ProjectClassificationDto> Children { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
