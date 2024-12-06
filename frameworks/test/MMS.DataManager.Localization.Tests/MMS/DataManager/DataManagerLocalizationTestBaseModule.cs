using Volo.Abp;
using Volo.Abp.Modularity;

namespace MMS.DataManager
{

    [DependsOn(typeof(DataManagerLocalizationModule))]
    [DependsOn(typeof(AbpTestBaseModule))]
    public class DataManagerLocalizationTestBaseModule : AbpModule
    {
    }
}
