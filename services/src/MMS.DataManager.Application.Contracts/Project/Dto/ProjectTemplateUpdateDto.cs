using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project.Dto
{
    public class ProjectTemplateUpdateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProjectTemplateData Data { get; set; }
    }
}
