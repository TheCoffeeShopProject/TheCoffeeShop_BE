using AutoMapper;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatBusinessObject.DTO.Response;

namespace TheCoffeeCatStore.Mapper
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailCreateDTO>()
                
                    .ForMember(
                dest => dest.MenuID,
                opt => opt.MapFrom(src => src.MenuID)
                )
                        .ForMember(
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity)
                )

                .ForMember(
                dest => dest.Amount,
                opt => opt.MapFrom(src => src.Amount)
                )
             
              
                .ForMember(
                dest => dest.OrderID,
                opt => opt.MapFrom(src => src.OrderID)
                )
                .ForMember(
                dest => dest.SubscriptionID,
                opt => opt.MapFrom(src => src.SubscriptionID)
                );



            CreateMap<OrderDetailCreateDTO, OrderDetail>()
                .ForMember(
               dest => dest.OrderDeatailID,
               opt => opt.MapFrom(src => Guid.NewGuid())
               )
                   .ForMember(
               dest => dest.MenuID,
               opt => opt.MapFrom(src => src.MenuID)
               )
                       .ForMember(
               dest => dest.Quantity,
               opt => opt.MapFrom(src => src.Quantity)
               )

               .ForMember(
               dest => dest.Amount,
               opt => opt.MapFrom(src => src.Amount)
               )


               .ForMember(
               dest => dest.OrderID,
               opt => opt.MapFrom(src => src.OrderID)
               )
               .ForMember(
               dest => dest.SubscriptionID,
               opt => opt.MapFrom(src => src.SubscriptionID)
               );



        }
    }
}
