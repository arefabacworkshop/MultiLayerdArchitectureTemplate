using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MappingProfiles
{
    internal class TemplateMapper : Profile
    {
        public TemplateMapper()
        {
            CreateMap<TemplateDTO, Template>()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.uid, opt => opt.MapFrom(src => src.uid));
            CreateMap<Template,TemplateDTO >()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.uid, opt => opt.MapFrom(src => src.uid));
        }
    }
}
