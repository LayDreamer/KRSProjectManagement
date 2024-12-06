using MMS.DataManager.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.Guids;

namespace MMS.DataManager.EntityFrameworkCore
{
    [DependsOn(
        typeof(DataManagerDomainModule),
        typeof(BasicManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(DataDictionaryManagementEntityFrameworkCoreModule),
        typeof(NotificationManagementEntityFrameworkCoreModule),
        typeof(LanguageManagementEntityFrameworkCoreModule)
        )]
    public class DataManagerEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            DataManagerEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DataManagerDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);

            });
            
            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also DataManagerMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}
