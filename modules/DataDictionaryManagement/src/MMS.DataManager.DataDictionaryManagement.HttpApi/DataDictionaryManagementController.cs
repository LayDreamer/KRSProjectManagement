using MMS.DataManager.DataDictionaryManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MMS.DataManager.DataDictionaryManagement
{
    public abstract class DataDictionaryManagementController : AbpController
    {
        protected DataDictionaryManagementController()
        {
            LocalizationResource = typeof(DataDictionaryManagementResource);
        }
    }
}
