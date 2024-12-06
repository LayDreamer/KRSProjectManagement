using MMS.DataManager.BasicManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MMS.DataManager.BasicManagement;

public abstract class BasicManagementController : AbpControllerBase
{
    protected BasicManagementController()
    {
        LocalizationResource = typeof(BasicManagementResource);
    }
}
