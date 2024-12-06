using MMS.DataManager.LanguageManagement.Languages;
using MMS.DataManager.LanguageManagement.LanguageTexts;

namespace MMS.DataManager.LanguageManagement
{
    public class LanguageManagementDomainAutoMapperProfile : Profile
    {
        public LanguageManagementDomainAutoMapperProfile()
        {
            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageText, LanguageTextDto>();
            CreateMap<Language, LanguageInfo>();
        }
    }
}