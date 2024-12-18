﻿using MMS.DataManager.Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace MMS.DataManager.Project.AggregateRoot
{
    public class ProjectTemplate : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// json序列化后 表单字段
        /// </summary>
        public ProjectTemplateData Data {  get; set; }

        public string CreateUser { get; set; }

        public string ModifyUser { get; set; }
    }
}
