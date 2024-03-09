using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class CustomerPackageDAO
    {
        private static CustomerPackageDAO instance;

        public static CustomerPackageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerPackageDAO();
                }
                return instance;
            }


        }

        public List<CustomerPackage> GetAllCustomerPackage()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.CustomerPackages.Include(c => c.Customer).Where(m=>m.DateEnd <DateTime.Now).ToList();
        }

        public bool AddNew(CustomerPackage customerPackage)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CustomerPackages.SingleOrDefault(c => c.CPID == customerPackage.CPID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.CustomerPackages.Add(customerPackage);
                _context.SaveChanges();
                return true;

            }
        }


        public bool Update(CustomerPackage customerPackage)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CustomerPackages.SingleOrDefault(c => c.CPID == customerPackage.CPID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(customerPackage);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ChangeStatus(CustomerPackage customerPackage)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CustomerPackages.FirstOrDefault(c => c.CPID.Equals(customerPackage.CPID));


            if (a == null)
            {
                return false;
            }
            else
            {            
                 _context.Entry(a).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }



        public CustomerPackage GetCPByID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.CustomerPackages.SingleOrDefault(a => a.CPID == id);
        }


        public IQueryable<CustomerPackage> SearchCPByName(string searchvalue)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.CustomerPackages.Where(a => a.Customer.FullName.ToUpper().Contains(searchvalue.Trim().ToUpper()));
            return a;
        }
    }
}
