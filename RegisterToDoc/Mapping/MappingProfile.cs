using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterToDoc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace RegisterToDoc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorVm>().ForMember(d => d.Avatar, f => f.MapFrom(src => "data:image/png;base64," + Convert.ToBase64String(src.Avatar)));
            CreateMap<DoctorVm, Doctor>();
            CreateMap<WorkGraphic, WorkGraphicVm>();
            CreateMap<WorkGraphicVm, WorkGraphic>();
        }       
    }
}

