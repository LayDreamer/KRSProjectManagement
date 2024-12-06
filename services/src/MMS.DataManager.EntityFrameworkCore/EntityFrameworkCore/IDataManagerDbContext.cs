using MMS.DataManager.Project.AggregateRoot;

namespace MMS.DataManager.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public interface IDataManagerDbContext : IEfCoreDbContext
    {
        DbSet<ProjectTemplate> ProjectTemplates { get; set; }
        DbSet<ProjectTemplateField> ProjectTemplateFields { get; set; }
        DbSet<ProjectInfo> Projects { get; set; }
        DbSet<ProjectFieldValue> ProjectFieldValues { get; set; }
    }
}
