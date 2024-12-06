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
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name {  get; set; }

        public Guid ProjectTemplateId { get; set; }

        public ProjectTemplate ProjectTemplate { get; set; }

        public List<ProjectFieldValue> FiledValues { get; set; }

        public ProjectInfo() 
        {
            FiledValues = new List<ProjectFieldValue>();
        }
    }
}
