namespace MMS.DataManager.Data
{
    public interface IDataManagerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
