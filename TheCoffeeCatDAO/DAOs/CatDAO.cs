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
    public class CatDAO
    {
        private static CatDAO instance = null;

        public static CatDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CatDAO();
                }
                return instance;
            }


        }

        public List<Cat> GetAllCat()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Cats!.Include(c => c.CoffeeShop).Where(c => c.Status == true).ToList();
        }

        public bool AddNew(Cat cat)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Cats!.SingleOrDefault(c => c.CatID == cat.CatID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Cats!.Add(cat);
                _context.SaveChanges();
                return true;

            }
        }


        public bool Update(Cat cat)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Cats!.SingleOrDefault(c => c.CatID == cat.CatID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(cat);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ChangeStatus(Cat cat)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Cats!.FirstOrDefault(c => c.CatID.Equals(cat.CatID));


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



        public Cat GetCatByID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Cats!.FirstOrDefault(a => a.CatID.Equals(id));
        }


        public IQueryable<Cat> SearchCatByName(string searchvalue)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Cats!.Where(a => a.Status == true && a.CatName.ToUpper().Contains(searchvalue.Trim().ToUpper()) );
            return a;
        }

        public IQueryable<Cat> SearchCatByCoffeeID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Cats!.Where(a => a.Status == true && a.CoffeeID == id);
            return a;
        }
    }
}
