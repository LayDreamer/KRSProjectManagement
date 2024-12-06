using Volo.Abp.Modularity;

namespace MMS.DataManager
{
    [DependsOn(
        typeof(DataManagerApplicationModule),
        typeof(DataManagerDomainTestModule)
        )]
    public class DataManagerApplicationTestModule : AbpModule
    {

    }
}