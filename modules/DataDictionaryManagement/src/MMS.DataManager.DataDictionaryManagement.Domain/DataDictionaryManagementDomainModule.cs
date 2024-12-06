using Volo.Abp.AutoMapper;

namespace MMS.DataManager.DataDictionaryManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DataDictionaryManagementDomainSharedModule),
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule)
    )]
    public class DataDictionaryManagementDomainModule : AbpModule
    {

    }
}
