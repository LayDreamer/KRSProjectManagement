using MMS.DataManager.Project.AggregateRoot;

namespace MMS.DataManager.EntityFrameworkCore
{
    public static class DataManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureDataManager(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));


            builder.Entity<ProjectTemplate>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectTemplate),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<ProjectTemplateField>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectTemplateField),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<ProjectInfo>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectInfo),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<ProjectFieldValue>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectFieldValue),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });
        }
    }
}