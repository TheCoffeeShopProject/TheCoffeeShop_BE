using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private CustomerDAO _cus;
        public CustomerRepo()
        {
            _cus = new CustomerDAO();
        }
        public void AddNew(Customer cus) => _cus.AddNew(cus);

        public bool ChangeStatus(Customer cus) => _cus.ChangeStatus(cus);

        public Customer GetCustomerById(Guid id) => _cus.GetCustomerByID(id);

        public List<Customer> GetCustomers() => _cus.GetAllCustomer();
        public IQueryable<Customer> SearchCustomer(string name) => _cus.SearchCustomerByName(name);

        public void UpdateCustomer(Customer cus) => _cus.Update(cus);
    }
}
