using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatRepository.IRepository
{
    public interface ICustomerRepo
    {
        public bool ChangeStatus(Customer cus);


        public List<Customer> GetCustomers();
        public void AddNew(Customer cus);


        public Customer GetCustomerById(Guid id);

        public void UpdateCustomer(Customer cus);

        public IQueryable<Customer> SearchCustomer(string name);
    }
}
