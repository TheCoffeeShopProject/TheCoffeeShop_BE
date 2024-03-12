using AutoMapper;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;

namespace TheCoffeeCatStore.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCreateDTO>()
                .ForMember(
                dest => dest.OrderID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
                .ForMember(
                dest => dest.CreateTime,
                opt => opt.MapFrom(src => DateTime.Now)
            )
                .ForMember(
                dest => dest.TotalPrice,
                opt => opt.MapFrom(src => src.TotalPrice)
            )
                .ForMember(
                dest => dest.TotalDiscount,
                opt => opt.MapFrom(src => src.TotalDiscount)
            )
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Status)
             )
                 .ForMember(
                dest => dest.StaffID,
                opt => opt.MapFrom(src => src.StaffID)
              )
                 .ForMember(
                dest => dest.CPID,
                opt => opt.MapFrom(src => src.CPID)
                )
                 .ForMember(
                dest => dest.TableID,
                opt => opt.MapFrom(src => src.TableID));


        }




    }
}
