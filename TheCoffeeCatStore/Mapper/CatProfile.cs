using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;

namespace TheCoffeeCatStore.Mapper
{
    public class CatProfile : Profile
    {
        public CatProfile()
        {
            CreateMap<CatDTO, Cat>()
            .ForMember(
                dest => dest.CatName,
                opt => opt.MapFrom(src => src.CatName)
            )
            .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.Age)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type)
            )
            .ForMember(
                dest => dest.Image,
                opt => opt.MapFrom(src => src.Image)
            )
            ;


            CreateMap<Cat, CatDTO>()
            .ForMember(
                dest => dest.CatName,
                opt => opt.MapFrom(src => src.CatName)
            )
            .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.Age)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type)
            )
            .ForMember(
                dest => dest.Image,
                opt => opt.MapFrom(src => src.Image)
            )
            ;
        }
    }
}
