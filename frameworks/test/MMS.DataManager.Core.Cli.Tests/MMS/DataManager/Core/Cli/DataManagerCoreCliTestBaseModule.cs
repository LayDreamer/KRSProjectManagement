using MMS.DataManager.Cli;
using MMS.DataManager.Cli.Options;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace MMS.DataManager.Core.Cli
{
    [DependsOn(typeof(AbpTestBaseModule),
        typeof(DataManagerCliCoreModule))]
    public class DataManagerCoreCliTestBaseModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
            Configure<DataManagerCliOptions>(options =>
            {
                options.Owner = "WangJunZzz";
                options.RepositoryId = "abp-vnext-pro";
                options.Token = "abp-vnext-proghp_47vqiabp-vnext-provNkHKJguOJkdHvnxUabp-vnext-protij7Qbdn1Qy3fUabp-vnext-pro";
            });
        }
    }
}