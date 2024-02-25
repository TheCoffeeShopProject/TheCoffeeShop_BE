using AutoMapper;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
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
            CreateMap<Drink, DrinkDTO>().ReverseMap()
                 .ForMember(
                dest => dest.DrinkID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );


            CreateMap<Account, AccountVM>().ReverseMap()
                .ForMember(
                dest => dest.AccountID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );
            CreateMap<Account, AccountDTO>().ReverseMap();


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



            CreateMap<Table, TableVM>().ReverseMap()
                .ForMember(
                dest => dest.TableID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            );
            CreateMap<Table, TableDTO>().ReverseMap();



            CreateMap<CatProduct, CatProductDTO>().ReverseMap()
                            .ForMember(dest => dest.CatProductID,
                                       opt => opt.MapFrom(src => Guid.NewGuid()));



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
