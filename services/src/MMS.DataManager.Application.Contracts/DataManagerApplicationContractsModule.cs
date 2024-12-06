namespace MMS.DataManager
{
    [DependsOn(
        typeof(DataManagerDomainSharedModule),
        typeof(AbpObjectExtendingModule),
        typeof(BasicManagementApplicationContractsModule),
        typeof(DataDictionaryManagementApplicationContractsModule),
        typeof(LanguageManagementApplicationContractsModule),
        typeof(NotificationManagementApplicationContractsModule)
    )]
    public class DataManagerApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            DataManagerDtoExtensions.Configure();
        }
    }
}
