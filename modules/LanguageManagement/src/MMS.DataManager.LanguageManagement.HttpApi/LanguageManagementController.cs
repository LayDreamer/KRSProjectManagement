using MMS.DataManager.LanguageManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MMS.DataManager.LanguageManagement
{
    public abstract class LanguageManagementController : AbpController
    {
        protected LanguageManagementController()
        {
            LocalizationResource = typeof(LanguageManagementResource);
        }
    }
}
