using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project
{
    public enum ProjectStatus
    {
        /// <summary>
        /// 进行中  （正常/预期）
        /// </summary>
        Progress = 0,

        /// <summary>
        /// 完成
        /// </summary>
        Finish = 1,

        /// <summary>
        /// 暂停
        /// </summary>
        Pause = 2,

        /// <summary>
        /// 取消
        /// </summary>
        Cancel = 4,
    }
}
