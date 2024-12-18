using MMS.DataManager.Project.AggregateRoot;
using MMS.DataManager.Project.Dto;
using Newtonsoft.Json;

namespace MMS.DataManager.EntityFrameworkCore
{
    public static class DataManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureDataManager(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<ProjectInfo>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectInfo),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<ProjectTemplate>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectTemplate),
                    DataManagerConsts.DbSchema);
                b.Property(u => u.Data).HasConversion(u =>
                  JsonConvert.SerializeObject(u), u => JsonConvert.DeserializeObject<ProjectTemplateData>(u));
                b.ConfigureByConvention();
            });

            builder.Entity<ProjectUser>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectUser),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<ProjectOrganization>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectOrganization),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });

            builder.Entity<ProjectClassification>(b =>
            {
                b.ToTable(DataManagerConsts.DbTablePrefix + nameof(ProjectClassification),
                    DataManagerConsts.DbSchema);
                b.ConfigureByConvention();
            });
        }
    }
}