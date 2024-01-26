using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class CoffeeShopServices : ICoffeeShopServices
    {
        private ICoffeeShopRepo _coffee;
             
        public CoffeeShopServices(ICoffeeShopRepo coffee)
        {
            _coffee = coffee;
        }

        public void AddNew(CoffeeShop coffeeShop)
        {
            _coffee.AddNew(coffeeShop);
        }

        public bool ChangeStatus(CoffeeShop coffeeShop)
        {
            return _coffee.ChangeStatus(coffeeShop);
        }

        public List<CoffeeShop> GetCoffees()
        {
            return _coffee.GetCoffees();
        }

        public CoffeeShop GetCoffeeShopById(Guid id)
        {
            return _coffee.GetCoffeeShopById(id);
        }

        public IQueryable<CoffeeShop> SearchCoffee(string name)
        {
            return _coffee.SearchCoffeeShop(name);
        }

        public void UpdateCoffee(CoffeeShop coffeeShop)
        {
            _coffee.UpdateCoffeeShop(coffeeShop);
        }
    }
}
