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
    public class MenuRepo : IMenuRepo
    {
        MenuDAO dao = new MenuDAO();

        public void AddNewMenu(Menu menu) => dao.AddNewMenu(menu);

        public bool ChangeStatusMenu(Menu menu) => dao.ChangeStatusMenu(menu);

        public List<Menu> GetAllMenu() => dao.GetAllMenu();

        public Menu GetMenuByID(Guid id) => dao.GetMenuByID(id);

        public void UpdateMenu(Menu menu) => dao.UpdateMenu(menu);
    }
}
