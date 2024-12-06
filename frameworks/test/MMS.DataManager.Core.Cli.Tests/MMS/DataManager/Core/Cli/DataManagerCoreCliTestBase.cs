using Volo.Abp;
using Volo.Abp.Testing;

namespace MMS.DataManager.Core.Cli
{
    public abstract class  DataManagerCoreCliTestBase : AbpIntegratedTest<DataManagerCoreCliTestBaseModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}