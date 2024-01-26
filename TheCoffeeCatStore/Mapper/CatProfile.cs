using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatBusinessObject.DTO.Response;

namespace TheCoffeeCatStore.Mapper
{
    public class CatProfile : Profile
    {
        public CatProfile()
        {
            CreateMap<CatCreateDTO, Cat>()
                .ForMember(
                dest => dest.CatID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
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
            ).ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status)
            )
            .ForMember(
                dest => dest.Image,
                opt => opt.MapFrom(src => src.Image)
            ).ForMember(
                dest => dest.CoffeeID,
                opt => opt.MapFrom(src => src.CoffeeID)
            )
            ;


            CreateMap<Cat, CatResponseDTO>()
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

            CreateMap<Cat, CatUpdateDTO>()

           .ForMember(
               dest => dest.Age,
               opt => opt.MapFrom(src => src.Age)
           )
           .ForMember(
               dest => dest.Description,
               opt => opt.MapFrom(src => src.Description)
           )
           .ForMember(
               dest => dest.Image,
               opt => opt.MapFrom(src => src.Image)
           )
           ;
        }
    }
}
