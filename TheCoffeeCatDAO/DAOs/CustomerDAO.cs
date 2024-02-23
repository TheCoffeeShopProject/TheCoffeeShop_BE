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
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }


        }

        public List<Customer> GetAllCustomer()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Customers.ToList();
        }

        public bool AddNew(Customer cus)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Customers.SingleOrDefault(c => c.CustomerID == cus.CustomerID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Customers.Add(cus);
                _context.SaveChanges();
                return true;

            }
        }


        public bool Update(Customer cus)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Customers.SingleOrDefault(c => c.CustomerID == cus.CustomerID );

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(cus);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ChangeStatus(Customer cus)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Customers.FirstOrDefault(c => c.CustomerID.Equals(cus.CustomerID));


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



        public Customer GetCustomerByID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Customers.SingleOrDefault(a => a.CustomerID == id);
        }


        public IQueryable<Customer> SearchCustomerByName(string searchvalue)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Customers.Where(a => a.FullName.ToUpper().Contains(searchvalue.Trim().ToUpper()));
            return a;
        }
    }
}
