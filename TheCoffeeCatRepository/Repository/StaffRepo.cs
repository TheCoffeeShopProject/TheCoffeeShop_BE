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
    public class StaffRepo : IStaffRepo
    {
        StaffDAO dao = new StaffDAO();
        public void AddNewStaff(Staff staff) => dao.AddNewStaff(staff);

        public List<Staff> GetAllStaff() => dao.GetAllStaff();

        public Staff GetStaffByID(Guid id) => dao.GetStaffByID(id);

        public void UpdateStaff(Staff staff) => dao.UpdateStaff(staff);

    }
}
