using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class DrinkRepo : IDrinkRepo
    {
        private DrinkDAO _drinkDAO;
        public DrinkRepo() {

            _drinkDAO = new DrinkDAO();
        }

        public IQueryable<Drink> GetAllByName(string name) => _drinkDAO.SearchDrinkByName(name);
        public Drink GetDrinkById(Guid id) => _drinkDAO.GetDrinkById(id);

        public List<Drink> GetDrinks() => _drinkDAO.GetDrinks();

        public void AddDrink(Drink drink)
        {
            _drinkDAO.AddDrink(drink);
        }

        public bool ChangeStatus(Drink drink)
        {
            return _drinkDAO.ChangeStatus(drink);
        }

        public void UpdateDrink(Drink drink)
        {
            _drinkDAO.UpdateDrink(drink);
        }

    }
}
