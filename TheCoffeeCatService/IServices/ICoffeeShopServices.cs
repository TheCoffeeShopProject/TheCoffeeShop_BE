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
        public bool ChangeStatus(CoffeeShop coffeeShop);

        public List<CoffeeShop> GetCoffees();
        public void AddNew(CoffeeShop coffeeShop);


        public CoffeeShop GetCoffeeShopById(Guid id);

        public void UpdateCoffee(CoffeeShop coffeeShop);

        public IQueryable<CoffeeShop> SearchCoffee(string name);
    }
}
