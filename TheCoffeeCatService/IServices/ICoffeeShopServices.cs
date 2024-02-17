using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface ICoffeeShopServices
    {
        bool ChangeStatus(CoffeeShop coffeeShop);

        List<CoffeeShop> GetCoffees();
        void AddNew(CoffeeShop coffeeShop);


        CoffeeShop GetCoffeeShopById(Guid id);

        void UpdateCoffee(CoffeeShop coffeeShop);

        IQueryable<CoffeeShop> SearchCoffee(string name);
    }
}
