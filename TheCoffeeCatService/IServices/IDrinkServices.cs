using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.DTO;

namespace TheCoffeeCatService.IServices
{
    public interface IDrinkServices
    {
        public List<Drink> GetDrinks();
        public Drink GetDrinkById(Guid id);
        public IQueryable<Drink> GetDrinkByName(string name);
        public void AddDrink(Drink drink);
        public void UpdateDrink(Drink drink);
        public bool ChangeStatus(Drink drink);
    }
}
