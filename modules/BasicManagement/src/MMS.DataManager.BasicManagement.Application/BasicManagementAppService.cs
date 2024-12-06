using MMS.DataManager.BasicManagement.Localization;

namespace MMS.DataManager.BasicManagement;

public abstract class BasicManagementAppService : ApplicationService
{
    protected BasicManagementAppService()
    {
        LocalizationResource = typeof(BasicManagementResource);
        ObjectMapperContext = typeof(BasicManagementApplicationModule);
    }
}
