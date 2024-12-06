using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MMS.DataManager.Project.AggregateRoot
{
    public class ProjectTemplateField : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 关联模板Id
        /// </summary>
        public Guid ProjectTemplateId { get; set; }

        public ProjectTemplate ProjectTemplate { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name {  get; set; }

        /// <summary>
        /// 字段标签
        /// </summary>
        public string FieldLable {  get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public ProjectFieldType FieldType {  get; set; }

        /// <summary>
        /// 是否必须的
        /// </summary>
        public bool IsRequired {  get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsVisible {  get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue {  get; set; }
    }
}
