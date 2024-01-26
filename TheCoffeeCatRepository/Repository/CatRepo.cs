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
    public class CatRepo : ICatRepo
    {
        private CatDAO dao;

        public CatRepo()
        {
            dao = new CatDAO();
        }

        public void AddNew(Cat cat)
        {
            dao.AddNew(cat);
        }

        public bool ChangeStatus(Cat cat)
        {
            return dao.ChangeStatus(cat);
        }

        public Cat GetCatById(Guid id)
        {
           return dao.GetCatByID(id);
        }

        public List<Cat> GetCats()
        {
         return dao.GetAllCat();   
        }

        public IQueryable<Cat> SearchCat(string name)
        {
           return dao.SearchCatByName(name);
        }

        public void UpdateCat(Cat cat)
        {
            dao.Update(cat);
         
        }
    }
}
