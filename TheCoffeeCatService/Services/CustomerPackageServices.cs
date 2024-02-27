using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class CustomerPackageServices : ICustomerPackageServices
    {
        private ICustomerPackageRepo _customerPackageRepo;
        public CustomerPackageServices(ICustomerPackageRepo customerPackageRepo)
        {
            _customerPackageRepo = customerPackageRepo;
        }
        public void AddNew(CustomerPackage customerPackage)
        {
            _customerPackageRepo.AddNew(customerPackage);
        }

        public bool ChangeStatus(CustomerPackage customerPackage)
        {
           return _customerPackageRepo.ChangeStatus(customerPackage);
        }

        public CustomerPackage GetCPById(Guid id)
        {
            return _customerPackageRepo.GetCPById(id);
        }

        public List<CustomerPackage> GetCPs()
        {
            return _customerPackageRepo.GetCustomerPackages();
        }

        public IQueryable<CustomerPackage> SearchCP(string name)
        {
            return _customerPackageRepo.SearchCP(name);
        }

        public void UpdateCP(CustomerPackage customerPackage)
        {
            _customerPackageRepo.UpdateCP(customerPackage);
        }
    }
}
