using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;

namespace TheCoffeeCatRepository.IRepository
{
    public interface IDrinkRepo
    {
        public List<Drink> GetDrinks();
        public Drink GetDrinkById(Guid id);
        public void AddDrink(Drink drink);
        public void UpdateDrink(Drink drink);
        public bool ChangeStatus(Drink drink);
        public IQueryable<Drink> GetAllByName(string name);
    }
}
