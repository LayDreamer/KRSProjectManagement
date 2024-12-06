using Volo.Abp.Modularity;

namespace MMS.DataManager.BasicManagement;

[DependsOn(
    typeof(BasicManagementApplicationModule),
    typeof(BasicManagementDomainTestModule)
    )]
public class BasicManagementApplicationTestModule : AbpModule
{

}
