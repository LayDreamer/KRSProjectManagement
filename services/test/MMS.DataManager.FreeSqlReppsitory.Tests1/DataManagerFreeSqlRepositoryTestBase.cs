using MMS.DataManager.FreeSqlReppsitory.Tests;
using MMS.DataManager.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager
{
    public abstract class DataManagerFreeSqlRepositoryTestBase: DataManagerTestBase<DataManagerFreeSqlRepositoryTestModule>
    {
        public DataManagerFreeSqlRepositoryTestBase()
        {
            ServiceProvider.InitializeLocalization();
        }
    }
}
