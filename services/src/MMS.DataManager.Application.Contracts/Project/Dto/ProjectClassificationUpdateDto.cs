using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project.Dto
{
    public class ProjectClassificationUpdateDto 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
