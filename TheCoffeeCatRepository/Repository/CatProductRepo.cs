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
    public class CatProductRepo : ICatProductRepo
    {
        private CatProductDAO catProductDAO;
        public CatProductRepo() {
        
        catProductDAO = new CatProductDAO();
        }
        public void AddCatProdct(CatProduct catProduct)
        {
            catProductDAO.AddNewCatProdct(catProduct);
        }

        public bool ChangeStatus(CatProduct catProduct)
        {
            return catProductDAO.ChangeStatus(catProduct);
        }

        public CatProduct GetCatProductById(Guid id)
        {
            return catProductDAO.GetCatProdctByID(id);
        }

        public List<CatProduct> GetCatProducts()
        {
            return catProductDAO.GetCatProducts();
        }

        public IQueryable<CatProduct> SearchCatProduct(string search)
        {
            return catProductDAO.SearchCatProdctByName(search);
        }

        public void UpdateCatProdct(CatProduct catProduct)
        {
             catProductDAO.UpdateCatProdct(catProduct);
        }
    }
}
