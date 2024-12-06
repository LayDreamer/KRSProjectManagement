using MMS.DataManager.BasicManagement;
using MMS.DataManager.LanguageManagement;
using MMS.DataManager.NotificationManagement;

namespace MMS.DataManager
{
    [DependsOn(
        typeof(DataManagerApplicationContractsModule),
        typeof(BasicManagementHttpApiClientModule),
        typeof(DataDictionaryManagementHttpApiClientModule),
        typeof(NotificationManagementHttpApiClientModule),
        typeof(LanguageManagementHttpApiClientModule)
    )]
    public class DataManagerHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DataManagerApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
