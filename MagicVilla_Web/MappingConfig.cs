using AutoMapper;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            _ = CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            _ = CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();
            _ = CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            _ = CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
