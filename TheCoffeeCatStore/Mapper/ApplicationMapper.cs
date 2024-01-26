using AutoMapper;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.ViewModels;

namespace TheCoffeeCatStore.Mapper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        { 
            CreateMap<Staff, StaffVM>().ReverseMap();



        }
    }
}
