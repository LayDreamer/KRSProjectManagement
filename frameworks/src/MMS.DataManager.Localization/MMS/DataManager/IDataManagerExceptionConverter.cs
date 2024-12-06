namespace MMS.DataManager;

public interface IDataManagerExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}