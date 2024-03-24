using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatRepository.Repository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class DrinkServices : IDrinkServices
    {
        private IDrinkRepo _drink;
        public DrinkServices(IDrinkRepo drink)
        {
            _drink = drink;
        }
        public void AddDrink(Drink drink)
        {
            _drink.AddDrink(drink);
        }

        public bool ChangeStatus(Drink drink)
        {
            return _drink.ChangeStatus(drink);
        }


        public Drink GetDrinkById(Guid id)
        {
            return _drink.GetDrinkById(id);
        }

        public IQueryable<Drink> GetDrinkByName(string name)
        {
            return _drink.GetAllByName(name);
        }

        public List<Drink> GetDrinks()
        {
            return _drink.GetDrinks();
        }

        public void UpdateDrink(Drink drink)
        {
            _drink.UpdateDrink(drink);
        }
        public int GetTotalDrinkCount()
        {
            return _drink.GetDrinks().Count;
        }

    }
}
