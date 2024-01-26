using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface IStaffServices
    {
        List<Staff> GetAllStaff();

        void AddNewStaff(Staff staff);

        Staff GetStaffByID(Guid id);

        void UpdateStaff(Staff staff);
    }
}
