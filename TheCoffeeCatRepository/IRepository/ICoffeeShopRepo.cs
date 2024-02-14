using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatRepository.IRepository
{
   public interface ICoffeeShopRepo
    {

        bool ChangeStatus(CoffeeShop coffeeShop);


        List<CoffeeShop> GetCoffees();
        void AddNew(CoffeeShop coffeeShop);


        CoffeeShop GetCoffeeShopById(Guid id);

        void UpdateCoffeeShop(CoffeeShop coffeeShop);

        IQueryable<CoffeeShop> SearchCoffeeShop(string name);
    }
}
