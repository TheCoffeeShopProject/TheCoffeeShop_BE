using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class CustomerServices : ICustomerServices
    {
        private ICustomerRepo _cus;
        public CustomerServices(ICustomerRepo cus) {
        _cus = cus;
        }
        public void AddNew(Customer cus) => _cus.AddNew(cus);

        public bool ChangeStatus(Customer cus) => _cus.ChangeStatus(cus);
        

        public Customer GetCustomerById(Guid id) => _cus.GetCustomerById(id);

        public List<Customer> GetCustomers() => _cus.GetCustomers();

        public IQueryable<Customer> SearchCustomer(string name) => _cus.SearchCustomer(name);

        public void UpdateCustomer(Customer cus) => _cus.UpdateCustomer(cus);
    }
}
