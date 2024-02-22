using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface IMenuServices
    {
        List<Menu> GetAllMenu();
        void AddNewMenu(Menu menu);
        Menu GetMenuByID(Guid id);
        void UpdateMenu(Menu menu);
        bool ChangeStatusMenu(Menu menu);
    }
}
