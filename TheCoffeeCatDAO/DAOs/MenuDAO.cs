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
    public class MenuDAO
    {
        private readonly TheCoffeeStoreDBContext _context;
        public MenuDAO()
        {
            _context = new TheCoffeeStoreDBContext();
        }

        public List<Menu> GetAllMenu()
        {
            try
            {
                return _context.Menus.Include(a => a.CoffeeShop)
                                     .Include(a => a.Drink)
                                     .Include(a => a.CatProduct)
                                     .Include(a => a.OrderDetails)
                                     .ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewMenu(Menu menu)
        {
            try
            {
                _context.Add(menu);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Menu GetMenuByID(Guid id)
        {
            try
            {
                var menu = _context.Menus.SingleOrDefault(c => c.MenuID == id);
                return menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMenu(Menu menu)
        {
            try
            {
                _context.Attach(menu).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeStatusMenu(Menu menu)
        {
            var _menu = _context.Menus.FirstOrDefault(c => c.MenuID.Equals(menu.MenuID));


            if (_menu == null)
            {
                return false;
            }
            else
            {
                _menu.Status = false;
                _context.Entry(_menu).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }


    }
}
