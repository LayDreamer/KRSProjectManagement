using MMS.DataManager.BasicManagement;
using MMS.DataManager.BasicManagement.Localization;
using MMS.DataManager.Core;
using MMS.DataManager.LanguageManagement;

namespace MMS.DataManager
{
    [DependsOn(
        typeof(DataManagerCoreModule),
        typeof(BasicManagementDomainSharedModule),
        typeof(DataDictionaryManagementDomainSharedModule),
        typeof(NotificationManagementDomainSharedModule),
        typeof(LanguageManagementDomainSharedModule)
    )]
    public class DataManagerDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            DataManagerGlobalFeatureConfigurator.Configure();
            DataManagerModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<DataManagerDomainSharedModule>(DataManagerDomainSharedConsts.NameSpace); });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<DataManagerResource>(DataManagerDomainSharedConsts.DefaultCultureName)
                    .AddVirtualJson("/Localization/DataManager")
                    .AddBaseTypes(typeof(BasicManagementResource))
                    .AddBaseTypes(typeof(AbpTimingResource));

                options.DefaultResourceType = typeof(DataManagerResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options => { options.MapCodeNamespace(DataManagerDomainSharedConsts.NameSpace, typeof(DataManagerResource)); });
        }
    }
}