using MMS.DataManager.Project.AggregateRoot;

namespace MMS.DataManager.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public interface IDataManagerDbContext : IEfCoreDbContext
    {
        DbSet<ProjectInfo> ProjectInfos { get; set; }
        DbSet<ProjectTemplate> ProjectTemplates { get; set; }
        DbSet<ProjectUser> ProjectUsers { get; set; }
        DbSet<ProjectOrganization> ProjectOrganizations { get; set; }
        DbSet<ProjectClassification> ProjectClassifications { get; set; }
    }
}
