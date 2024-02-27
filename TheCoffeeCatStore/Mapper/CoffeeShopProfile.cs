using AutoMapper;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatBusinessObject.DTO.Response;

namespace TheCoffeeCatStore.Mapper
{
    public class CoffeeShopProfile : Profile
    {
        public CoffeeShopProfile()
        {
            CreateMap<CoffeeShop, CoffeeResponseDTO>()
                .ForMember(
                dest => dest.CoffeeName,
                opt => opt.MapFrom(src => src.CoffeeName)
                )
                .ForMember(
                dest => dest.OpenTime,
                opt => opt.MapFrom(src => src.OpenTime)
                )
                .ForMember(
                dest => dest.CloseTime,
                opt => opt.MapFrom(src => src.CloseTime)
                )
                .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber)
                )
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(
                dest => dest.Image,
                opt => opt.MapFrom(src => src.Image)
                ) ;

            CreateMap<CoffeeCreateDTO, CoffeeShop>()
               .ForMember(
               dest => dest.CoffeeName,
               opt => opt.MapFrom(src => src.CoffeeName)
               )
               .ForMember(
               dest => dest.OpenTime,
               opt => opt.MapFrom(src => src.OpenTime)
               )
               .ForMember(
               dest => dest.CloseTime,
               opt => opt.MapFrom(src => src.CloseTime)
               )
                .ForMember(
               dest => dest.Address,
               opt => opt.MapFrom(src => src.Address)
               )
               .ForMember(
               dest => dest.PhoneNumber,
               opt => opt.MapFrom(src => src.PhoneNumber)
               )
               .ForMember(
               dest => dest.Description,
               opt => opt.MapFrom(src => src.Description)
               )
                 .ForMember(
               dest => dest.Status,
               opt => opt.MapFrom(src => src.Status)
               )
               .ForMember(
               dest => dest.Image,
               opt => opt.MapFrom(src => src.Image)
               );

            CreateMap<CoffeeUpdateDTO, CoffeeShop>()
         
             .ForMember(
             dest => dest.OpenTime,
             opt => opt.MapFrom(src => src.OpenTime)
             )
             .ForMember(
             dest => dest.CloseTime,
             opt => opt.MapFrom(src => src.CloseTime)
             )
           
             .ForMember(
             dest => dest.PhoneNumber,
             opt => opt.MapFrom(src => src.PhoneNumber)
             )
             .ForMember(
             dest => dest.Description,
             opt => opt.MapFrom(src => src.Description)
             )
               .ForMember(
             dest => dest.Status,
             opt => opt.MapFrom(src => src.Status)
             )
             .ForMember(
             dest => dest.Image,
             opt => opt.MapFrom(src => src.Image)
             );



        }
    }
}
