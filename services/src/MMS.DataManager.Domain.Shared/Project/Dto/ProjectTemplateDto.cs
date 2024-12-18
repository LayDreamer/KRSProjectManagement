using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project.Dto
{
    public class ProjectTemplateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// json序列化后 表单字段
        /// </summary>
        public ProjectTemplateData Data { get; set; }

        public string CreateUser { get; set; }

        public string ModifyUser { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
