using Volo.Abp.DependencyInjection;

namespace MMS.DataManager.BasicManagement.Data
{
    /* This is used if database provider does't define
     * IDataManagerDbSchemaMigrator implementation.
     */
    public class NullDataManagerDbSchemaMigrator : IDataManagerDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}