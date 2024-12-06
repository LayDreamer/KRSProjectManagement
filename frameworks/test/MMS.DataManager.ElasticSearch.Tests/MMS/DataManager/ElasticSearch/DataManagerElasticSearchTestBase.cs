using Volo.Abp.Testing;

namespace MMS.DataManager.ElasticSearch
{

    public abstract class DataManagerElasticSearchTestBase : AbpIntegratedTest<DataManagerElasticSearchTestBaseModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
