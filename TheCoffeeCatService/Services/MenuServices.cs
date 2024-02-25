using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepo _menuRepo;
        public MenuServices(IMenuRepo menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public void AddNewMenu(Menu menu) => _menuRepo.AddNewMenu(menu);

        public bool ChangeStatusMenu(Menu menu) => _menuRepo.ChangeStatusMenu(menu);

        public List<Menu> GetAllMenu() => _menuRepo.GetAllMenu();

        public Menu GetMenuByID(Guid id) => _menuRepo.GetMenuByID(id);

        public IQueryable<Menu> GetMenuByShopID(Guid id) => _menuRepo.GetMenuByShopID(id);

        public void UpdateMenu(Menu menu) => _menuRepo.UpdateMenu(menu);

    }
}
