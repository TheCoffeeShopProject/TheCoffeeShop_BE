using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class CatProductDAO
    {
        private static CatProductDAO instance;
        private static CatProductDAO Instance
        {
            get
            {if (instance == null)
                {
                    instance = new CatProductDAO();
                }
                return instance;

            }
        }
        public List<CatProduct> GetCatProducts()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.CatProducts.Where( m => m.Status ==true ).ToList();

        }
        public bool AddNewCatProdct(CatProduct catProduct)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CatProducts.SingleOrDefault(x => x.CatProductID == catProduct.CatProductID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.CatProducts.Add(catProduct);
                _context.SaveChanges();
                return true;
            }

        }

        public bool UpdateCatProdct(CatProduct catProduct)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CatProducts.SingleOrDefault(c => c.CatProductID == catProduct.CatProductID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(catProduct);
                _context.SaveChanges();
                return true;
            }
        }


        public bool ChangeStatus(CatProduct catProduct)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CatProducts.SingleOrDefault(c => c.CatProductID == catProduct.CatProductID);

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

        public CatProduct GetCatProdctByID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.CatProducts.SingleOrDefault(a => a.CatProductID == id);
        }


        public IQueryable<CatProduct> SearchCatProdctByName(string search)
        {
            var _context = new TheCoffeeStoreDBContext();
            return  _context.CatProducts.Where(a => a.CatProductName.ToUpper().Contains(search.Trim().ToUpper()));
        }

        





    }
}
