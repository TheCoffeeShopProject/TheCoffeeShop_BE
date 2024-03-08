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
    public class DrinkDAO
    {
        public static DrinkDAO instance;
        public static DrinkDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DrinkDAO();
                }
                return instance;
            }

        }
        public List<Drink> GetDrinks()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Drinks.Include(m => m.Menus).Where(m => m.Status == true).ToList();
        }
        public Drink GetDrinkById(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Drinks.SingleOrDefault(m => m.DrinkID == id);


        }
        public bool AddDrink(Drink drink)
        {

            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Drinks.SingleOrDefault(d => d.DrinkID == drink.DrinkID);
            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Drinks.Add(drink);
                _context.SaveChanges();
                return true;
            }

        }
        public bool UpdateDrink(Drink drink)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Drinks.SingleOrDefault(d => d.DrinkID == drink.DrinkID);
            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(drink);
                _context.SaveChanges();
                return true;
            }
        }
        public IQueryable<Drink> SearchDrinkByName(string search)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Drinks.Where(a => a.DrinkName.ToUpper().Contains(search.Trim().ToUpper()));
            return a;
        }
        public bool ChangeStatus(Drink drink) {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Drinks.FirstOrDefault(d => d.DrinkID == drink.DrinkID);
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
    }
}
