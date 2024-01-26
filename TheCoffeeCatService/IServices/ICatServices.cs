using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface ICatServices
    {
        public bool ChangeStatus(Cat cat);

        public List<Cat> GetCats();
        public void AddNew(Cat cat);


        public Cat GetCatById(Guid id);

        public void UpdateCat(Cat cat);

        public IQueryable<Cat> SearchCat(string name);
    }
}
