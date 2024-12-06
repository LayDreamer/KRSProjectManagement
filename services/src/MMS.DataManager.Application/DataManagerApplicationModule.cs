namespace MMS.DataManager
{
    [DependsOn(
        typeof(DataManagerDomainModule),
        typeof(DataManagerApplicationContractsModule),
        typeof(BasicManagementApplicationModule),
        typeof(DataDictionaryManagementApplicationModule),
        typeof(NotificationManagementApplicationModule),
        typeof(LanguageManagementApplicationModule),
        typeof(NotificationManagementApplicationModule),
        typeof(DataManagerFreeSqlModule)
    )]
    public class DataManagerApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options => { options.AddMaps<DataManagerApplicationModule>(); });
        }
    }
}