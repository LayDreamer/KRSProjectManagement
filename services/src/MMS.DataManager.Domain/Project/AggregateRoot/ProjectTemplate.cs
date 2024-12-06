using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MMS.DataManager.Project.AggregateRoot
{
    public  class ProjectTemplate : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模板描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模板下定义的字段
        /// </summary>
        public List<ProjectTemplateField> Fields { get; set; }


        public ProjectTemplate() 
        {
            Fields = new List<ProjectTemplateField>();
        }
    }
}
