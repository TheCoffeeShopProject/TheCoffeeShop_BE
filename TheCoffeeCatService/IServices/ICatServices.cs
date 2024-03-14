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
        bool ChangeStatus(Cat cat);

        List<Cat> GetCats();
        void AddNew(Cat cat);


        Cat GetCatById(Guid id);

        void UpdateCat(Cat cat);

        IQueryable<Cat> SearchCat(string name);
        IQueryable<Cat> SearchCatByCoffeeID(Guid id);
    }
}
