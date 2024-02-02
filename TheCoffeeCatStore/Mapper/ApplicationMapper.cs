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
