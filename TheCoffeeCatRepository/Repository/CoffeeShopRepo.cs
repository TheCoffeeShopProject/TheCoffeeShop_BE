using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class CoffeeShopRepo : ICoffeeShopRepo
    {
        private CoffeeShopDAO dao;
        public CoffeeShopRepo()
        {
            dao = new CoffeeShopDAO();
        }

        public void AddNew(CoffeeShop coffeeShop)
        {
            dao.AddNewCoffee(coffeeShop);
        }

        public bool ChangeStatus(CoffeeShop coffeeShop)
        {
            return dao.ChangeStatus(coffeeShop);
        }

        public List<CoffeeShop> GetCoffees()
        {
            return dao.GetAllCoffee();
        }

        public CoffeeShop GetCoffeeShopById(Guid id)
        {
            return dao.GetCoffeeShopByID(id);
        }

        public IQueryable<CoffeeShop> SearchCoffeeShop(string name)
        {
            return dao.SearchCoffeeShopByName(name);
        }

        public void UpdateCoffeeShop(CoffeeShop coffeeShop)
        {
            dao.UpdateCoffee(coffeeShop);
        }
    }
}
