using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class CoffeeShopDAO
    {

        private static CoffeeShopDAO instance;

        public static CoffeeShopDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CoffeeShopDAO();
                }
                return instance;
            }


        }

        public List<CoffeeShop> GetAllCoffee()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.CofffeeShops.Where(c => c.Status).ToList();
        }

        public bool AddNewCoffee(CoffeeShop coffeeShop)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CofffeeShops.SingleOrDefault(x => x.CoffeeID == coffeeShop.CoffeeID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.CofffeeShops.Add(coffeeShop);
                _context.SaveChanges();
                return true;
            }

        }

        public bool UpdateCoffee(CoffeeShop coffeeShop)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CofffeeShops.SingleOrDefault(c => c.CoffeeID == coffeeShop.CoffeeID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(coffeeShop);
                _context.SaveChanges();
                return true;
            }
        }


        public bool ChangeStatus(CoffeeShop coffeeShop)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CofffeeShops.SingleOrDefault(c => c.CoffeeID.Equals( coffeeShop.CoffeeID));


            if (a == null)
            {
                return false;
            }
            else
            {
                a.Status = false;
                _context.Entry(a).State = EntityState.Modified;

                _context.SaveChanges();
                return true;
            }
        }

        public CoffeeShop GetCoffeeShopByID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.CofffeeShops.SingleOrDefault(a => a.CoffeeID == id);
        }


        public IQueryable<CoffeeShop> SearchCoffeeShopByName(string searchvalue)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CofffeeShops.Where(a => a.CoffeeName.ToUpper().Contains(searchvalue.Trim().ToUpper()));
            return a;
        }





    }
}
