namespace MMS.DataManager.BasicManagement.Data
{
    public interface IDataManagerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
