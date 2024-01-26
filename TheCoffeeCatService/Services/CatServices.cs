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
    public class CatServices : ICatServices
    {
        private ICatRepo _cat;

        public CatServices( ICatRepo cat)
        {
            _cat = cat;
        }

        public void AddNew(Cat cat)
        {
            _cat.AddNew(cat);
        }

        public bool ChangeStatus(Cat cat)
        {
            return _cat.ChangeStatus(cat);
        }

        public Cat GetCatById(Guid id)
        {
            return _cat.GetCatById(id);
        }

        public List<Cat> GetCats()
        {
            return _cat.GetCats();
        }

        public IQueryable<Cat> SearchCat(string name)
        {
          return _cat.SearchCat(name);
        }

        public void UpdateCat(Cat cat)
        {
         _cat.UpdateCat(cat);
        }
    }
}
