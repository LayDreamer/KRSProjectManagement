using Volo.Abp;
using Volo.Abp.Testing;

namespace MMS.DataManager.Core
{
    public abstract class  DataManagerTestBase : AbpIntegratedTest<DataManagerTestBaseModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}