using AutoMapper;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.ViewModels;

namespace TheCoffeeCatStore.Mapper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        { 
            CreateMap<Staff, StaffVM>().ReverseMap();
            CreateMap<Drink, DrinkDTO>().ReverseMap();
                //.BeforeMap((DrinkDTO, Drink) =>
                //{
                //    if(DrinkDTO.DrinkName != null)
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
                // });



        }
    }
}
