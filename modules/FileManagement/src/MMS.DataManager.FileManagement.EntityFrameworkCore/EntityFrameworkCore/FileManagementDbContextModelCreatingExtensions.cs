namespace MMS.DataManager.FileManagement.EntityFrameworkCore;

public static class FileManagementDbContextModelCreatingExtensions
{
    public static void ConfigureFileManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));


        builder.Entity<MMS.DataManager.FileManagement.Files.File>(b =>
        {
            b.ToTable(FileManagementDbProperties.DbTablePrefix + nameof(MMS.DataManager.FileManagement.Files.File), FileManagementDbProperties.DbSchema);
            b.HasIndex(q => q.FileName);
            b.HasIndex(q => q.CreationTime);
            b.ConfigureByConvention();
        });
    }
}