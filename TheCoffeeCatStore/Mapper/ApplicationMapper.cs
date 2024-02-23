using AutoMapper;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatBusinessObject.DTO.Response;
using TheCoffeeCatBusinessObject.ViewModels;

namespace TheCoffeeCatStore.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Staff, StaffVM>().ReverseMap()
                .ForMember(
                dest => dest.StaffID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );
            CreateMap<Staff, StaffDTO>().ReverseMap();
            CreateMap<Drink, DrinkResponseDTO>().ReverseMap()
                 .ForMember(
                dest => dest.DrinkID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );
            CreateMap<Drink, DrinkCreateDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap()
               .ForMember(
              dest => dest.CustomerID,
              opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<Subscription, SubscriptionDTO>().ReverseMap()
                 .ForMember(
                dest => dest.SubscriptionID,
                opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<CustomerPackage, CustomerPackageDTO>().ReverseMap()
                .ForMember(dest => dest.CPID,
                                       opt => opt.MapFrom(src => Guid.NewGuid()));



            CreateMap<Account, AccountVM>().ReverseMap()
                .ForMember(
                dest => dest.AccountID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );
            CreateMap<Account, AccountDTO>().ReverseMap();

            CreateMap<CatProduct, CatProductResponse>().ReverseMap()
                            .ForMember(dest => dest.CatProductID,
                                       opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<CatProduct, CatProductCreate>().ReverseMap();



            //.BeforeMap((DrinkDTO, Drink) =>
            //{
            //    if (DrinkDTO.DrinkName != null)
            //    {
            //        Drink.DrinkName = DrinkDTO.DrinkName;
            //    }
            //    if (DrinkDTO.Status != null)
            //    {
            //        Drink.Status = DrinkDTO.Status;
            //    }
            //    if (DrinkDTO.UnitPrice != null)
            //    {
            //        Drink.UnitPrice = DrinkDTO.UnitPrice;
            //    }
            //    if (DrinkDTO.Image != null)
            //    {
            //        Drink.Image = DrinkDTO.Image;
            //    }
            //});



        }
    }
}
