using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project.Dto
{
    public class ProjectStartMettigDto
    {
    }

    /// <summary>
    /// 项目分析
    /// </summary>
    public class ProjectAnalyzeData
    {
        public string Description { get; set; }

        public string Value { get; set; }
    }

    /// <summary>
    /// 项目参考性能分析
    /// </summary>

    public class ProjectReference
    {
        public string Description { get; set; }

        public string Value { get; set; }
    }

    /// <summary>
    /// 项目原因分析
    /// </summary>
    public class ProjectCauseAnalysis
    {
        public string Description { get; set; }

        public string Value { get; set; }

        public string Department { get; set; }
    }

    /// <summary>
    /// 项目负责人
    /// </summary>
    public class ProjectImprovementplan
    {
        public string Description { get; set; }

        public string Value { get; set; }

        public string CChargePerson { get; set; }
    }
}
