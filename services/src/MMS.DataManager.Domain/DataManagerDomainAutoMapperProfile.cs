using AutoMapper;
using MMS.DataManager.Project.AggregateRoot;
using MMS.DataManager.Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DataManager
{
    public class DataManagerDomainAutoMapperProfile : Profile
    {
        public DataManagerDomainAutoMapperProfile()
        {
            CreateMap<ProjectClassification, ProjectClassificationDto>();
            CreateMap<ProjectTemplate, ProjectTemplateDto>();
        }
    }
}
