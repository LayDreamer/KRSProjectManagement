using MMS.DataManager.LanguageManagement.Languages;
using MMS.DataManager.LanguageManagement.LanguageTexts;

namespace MMS.DataManager.LanguageManagement
{
    public class LanguageManagementApplicationAutoMapperProfile : Profile
    {
        public LanguageManagementApplicationAutoMapperProfile()
        {
            CreateMap<LanguageDto, PageLanguageOutput>();
            CreateMap<Language, PageLanguageOutput>();
            CreateMap<LanguageTextDto, PageLanguageTextOutput>();
        }
    }
}