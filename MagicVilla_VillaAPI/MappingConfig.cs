using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            _ = CreateMap<Villa, VillaDTO>().ReverseMap();
            _ = CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            _ = CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
            _ = CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            _ = CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            _ = CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
