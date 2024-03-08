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
            CreateMap<StaffVM, Staff>().ReverseMap().ForMember(dest => dest.CoffeeName,
                                       opt => opt.MapFrom(src => src.CoffeeShop!.CoffeeName))
                                                    .ForMember(dest => dest.Email,
                                       opt => opt.MapFrom(src => src.Account!.Email));
            CreateMap<StaffDTO, Staff>().ReverseMap();
            //drink
            CreateMap<Drink, DrinkCreateDTO>().ReverseMap()
                 .ForMember(
                dest => dest.DrinkID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );
            CreateMap<Drink, DrinkResponseDTO>().ReverseMap();
            CreateMap<Drink, DrinkUpdateDTO>().ReverseMap();
            //customer
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap()
               .ForMember(
              dest => dest.CustomerID,
              opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerResponseDTO>().ReverseMap();

            //subscription
            CreateMap<Subscription, SubscriptionCreateDTO>().ReverseMap()
                 .ForMember(
                dest => dest.SubscriptionID,
                opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<Subscription, SubscriptionUpdateDTO>().ReverseMap();
            CreateMap<Subscription, SubscriptionResponseDTO>().ReverseMap();

            //customerPackage
            CreateMap<CustomerPackage, CustomerPackageCreateDTO>().ReverseMap()
                .ForMember(dest => dest.CPID,
                                       opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<CustomerPackage, CustomerPackageResponseDTO>().ReverseMap();
            CreateMap<CustomerPackage, CustomerPackageUpdateDTO>().ReverseMap();
            //catProduct
            CreateMap<CatProduct, CatProductResponse>().ReverseMap()
                           .ForMember(dest => dest.CatProductID,
                                      opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<CatProduct, CatProductCreate>().ReverseMap();
            CreateMap<CatProduct, CatProductUpdateDTO>().ReverseMap();

            //----------

            CreateMap<AccountVM, Account>().ReverseMap().ForMember(dest => dest.RoleName,
                                       opt => opt.MapFrom(src => src.Role!.RoleName));
            CreateMap<AccountDTO, Account>().ReverseMap();


            CreateMap<MenuDTO, Menu>().ReverseMap();
            CreateMap<MenuVM, Menu>().ReverseMap().ForMember(dest => dest.CatProductName,
                                       opt => opt.MapFrom(src => src.CatProduct!.CatProductName))
                                                   .ForMember(dest => dest.DrinkName,
                                       opt => opt.MapFrom(src => src.Drink!.DrinkName))
                                                   .ForMember(dest => dest.CoffeeName,
                                       opt => opt.MapFrom(src => src.CoffeeShop!.CoffeeName))
                                                   .ForMember(dest => dest.PriceDrink,
                                       opt => opt.MapFrom(src => src.Drink!.UnitPrice))
                                                   .ForMember(dest => dest.PriceCatProduct,
                                       opt => opt.MapFrom(src => src.CatProduct!.Price)); ;



            CreateMap<TableVM, Table>().ReverseMap().ForMember(dest => dest.CoffeeName,
                                       opt => opt.MapFrom(src => src.CoffeeShop!.CoffeeName));
            CreateMap<TableDTO, Table>().ReverseMap();



           

            
            


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
