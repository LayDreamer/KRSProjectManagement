using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MMS.DataManager.Project.AggregateRoot
{
    public class ProjectFieldValue : BasicAggregateRoot<Guid>
    {
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public Guid ProjectTemplateField { get; set; }

        public ProjectTemplateField Field { get; set; }

        /// <summary>
        /// 字段值
        /// </summary>
        public string Value {  get; set; }

    }
}
