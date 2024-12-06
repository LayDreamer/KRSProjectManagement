using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager
{
    public class ApiResultDto
    {
        public int Code { get; set; }

        public string Error { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public Object Data { get; set; }
    }
}
