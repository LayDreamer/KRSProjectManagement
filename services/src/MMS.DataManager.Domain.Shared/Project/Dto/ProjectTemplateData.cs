using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project.Dto
{

    public class ProjectTemplateData
    {
        public bool OpenProjectTarget { get; set; }

        /// <summary>
        /// true 项目目标是表格 false 项目目标是文本
        /// </summary>
        public bool ProjectTargetSheet { get; set; }

        public List<string> ProjectTargetSheetCols { get; set; }

        public List<string> ProjectTargetSheetRows { get; set; }

        public bool OpenProjectAnalyza { get; set; }

        /// <summary>
        ///  项目分析
        /// </summary>
        public List<string> ProjectAnalyzeDatas { get; set; }

        public bool OpenProjectReference { get; set; }

        /// <summary>
        ///  项目参考性能分析
        /// </summary>
        public List<string> ProjectReferences { get; set; }

        public bool OpenProjectCauseAnalysis { get; set; }

        /// <summary>
        /// 项目原因分析
        /// </summary>
        public List<string> ProjectCauseAnalysiss { get; set; }

        public bool OpenProjectImprovementplan { get; set; }

        /// <summary>
        /// 改善方案
        /// </summary>
        public List<string> ProjectImprovementplans {  get; set; }

        /// <summary>
        /// 问题定义D
        /// </summary>
        public bool OpenProblemDefinitionD { get; set; } = false;

        /// <summary>
        /// 当前损失M
        /// </summary>
        public bool OpenCurrentLossM { get; set; } = false;
    }
}
