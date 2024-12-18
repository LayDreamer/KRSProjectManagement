using MMS.DataManager.DataDictionaryManagement.DataDictionaries.Aggregates;
using MMS.DataManager.LanguageManagement.EntityFrameworkCore;
using MMS.DataManager.LanguageManagement.Languages.Aggregates;
using MMS.DataManager.LanguageManagement.LanguageTexts.Aggregates;
using MMS.DataManager.NotificationManagement.Notifications.Aggregates;
using MMS.DataManager.Project.AggregateRoot;

namespace MMS.DataManager.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See DataManagerMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class DataManagerDbContext : AbpDbContext<DataManagerDbContext>, IDataManagerDbContext,
        IBasicManagementDbContext,
        INotificationManagementDbContext,
        IDataDictionaryManagementDbContext,
        ILanguageManagementDbContext
    {
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
        public DbSet<IdentitySession> Sessions { get; set; }
        public DbSet<FeatureGroupDefinitionRecord> FeatureGroups { get; set; }
        public DbSet<FeatureDefinitionRecord> Features { get; set; }
        public DbSet<FeatureValue> FeatureValues { get; set; }
        public DbSet<PermissionGroupDefinitionRecord> PermissionGroups { get; set; }
        public DbSet<PermissionDefinitionRecord> Permissions { get; set; }
        public DbSet<PermissionGrant> PermissionGrants { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingDefinitionRecord> SettingDefinitionRecords { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
        public DbSet<BackgroundJobRecord> BackgroundJobs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }
        public DbSet<DataDictionary> DataDictionaries { get;  set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageText> LanguageTexts { get; set; }
        public DbSet<ProjectInfo> ProjectInfos { get; set; }
        public DbSet<ProjectTemplate> ProjectTemplates { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<ProjectOrganization> ProjectOrganizations { get; set; }
        public DbSet<ProjectClassification> ProjectClassifications { get; set; }

        public DataManagerDbContext(DbContextOptions<DataManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // 如何设置表前缀
            // Abp框架表前缀 Abp得不建议修改表前缀
            // AbpCommonDbProperties.DbTablePrefix = "xxx";
            
            // 数据字典表前缀
            //DataDictionaryManagementDbProperties=“xxx”
            // 通知模块
            //NotificationManagementDbProperties = "xxx"
            base.OnModelCreating(builder);

          
            builder.ConfigureDataManager();

            // 基础模块
            builder.ConfigureBasicManagement();

            // 数据字典
            builder.ConfigureDataDictionaryManagement();

            // 消息通知
            builder.ConfigureNotificationManagement();
            
            // 多语言
            builder.ConfigureLanguageManagement();
        }

    }
}