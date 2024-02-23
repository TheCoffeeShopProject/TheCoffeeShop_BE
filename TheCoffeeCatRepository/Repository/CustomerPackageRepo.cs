using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class CustomerPackageRepo : ICustomerPackageRepo
    {
        private CustomerPackageDAO dao;

        public CustomerPackageRepo()
        {
            dao = new CustomerPackageDAO();
        }
        public void AddNew(CustomerPackage customerPackage)
        {
            dao.AddNew(customerPackage);
        }

        public bool ChangeStatus(CustomerPackage customerPackage)
        {
           return  dao.ChangeStatus(customerPackage);
        }

        public CustomerPackage GetCPById(Guid id)
        {
           return   dao.GetCPByID(id);
        }

        public List<CustomerPackage> GetCustomerPackages()
        {
           return dao.GetAllCustomerPackage();
        }

        public IQueryable<CustomerPackage> SearchCP(string name)
        {
            return dao.SearchCPByName(name);
        }

        public void UpdateCP(CustomerPackage customerPackage)
        {
            dao.Update(customerPackage);
        }
    }
}
