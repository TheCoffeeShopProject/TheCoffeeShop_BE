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
    public class CatProductServices : ICatProductServices
    {
        private ICatProductRepo catProductRepo;
        public CatProductServices(ICatProductRepo _catProductRepo)
        {
            catProductRepo = _catProductRepo;

        }
        public void AddCatProdct(CatProduct catProduct)
        {
            catProductRepo.AddCatProdct(catProduct);
        }

        public bool ChangeStatus(CatProduct catProduct)
        {
            return catProductRepo.ChangeStatus(catProduct);
        }

        public CatProduct GetCatProductById(Guid id)
        {
            return catProductRepo.GetCatProductById(id);
        }

        public List<CatProduct> GetCatProducts()
        {
            return catProductRepo.GetCatProducts();
        }

        public IQueryable<CatProduct> SearchCatProduct(string search)
        {
            return catProductRepo.SearchCatProduct(search);
        }

        public void UpdateCatProdct(CatProduct catProduct)
        {
            catProductRepo.UpdateCatProdct(catProduct);
        }
    }
}
