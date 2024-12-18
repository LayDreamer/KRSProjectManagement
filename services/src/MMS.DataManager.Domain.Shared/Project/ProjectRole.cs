using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager.Project
{
    public enum ProjectRole
    {
        /// <summary>
        /// 负责人
        /// </summary>
        Charge = 0,

        /// <summary>
        /// 第二负责人
        /// </summary>
        SecondCharge = 1,

        /// <summary>
        /// 审核人
        /// </summary>
        Audit = 2,

        /// <summary>
        /// 成员
        /// </summary>
        Member = 4,
    }
}
