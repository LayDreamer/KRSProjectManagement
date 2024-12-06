namespace MMS.DataManager.FileManagement;

public class FileManagementApplicationAutoMapperProfile : Profile
{
    public FileManagementApplicationAutoMapperProfile()
    {
        CreateMap<MMS.DataManager.FileManagement.Files.File, PagingFileOutput>();
    }
}