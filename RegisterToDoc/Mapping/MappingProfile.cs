using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterToDoc.Models;
using AutoMapper;

namespace RegisterToDoc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorVm>().ReverseMap();
            CreateMap<WorkGraphic, WorkGraphicVm>();
            CreateMap<WorkGraphicVm, WorkGraphic>();

        }
    }
}

