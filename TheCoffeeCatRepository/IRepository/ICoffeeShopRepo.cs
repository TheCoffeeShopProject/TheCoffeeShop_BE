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

        public bool ChangeStatus(CoffeeShop coffeeShop);


        public List<CoffeeShop> GetCoffees();
        public void AddNew(CoffeeShop coffeeShop);


        public CoffeeShop GetCoffeeShopById(Guid id);

        public void UpdateCoffeeShop(CoffeeShop coffeeShop);

        public IQueryable<CoffeeShop> SearchCoffeeShop(string name);
    }
}
