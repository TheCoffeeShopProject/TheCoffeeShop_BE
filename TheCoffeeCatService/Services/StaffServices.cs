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
    public class StaffServices : IStaffServices
    {
        private readonly IStaffRepo _staffRepo;
        public StaffServices(IStaffRepo staffRepo)
        {
            _staffRepo = staffRepo;
        }

        public List<Staff> GetAllStaff() => _staffRepo.GetAllStaff();
        public void AddNewStaff(Staff staff) => _staffRepo.AddNewStaff(staff);

        public Staff GetStaffByID(Guid id) => _staffRepo.GetStaffByID(id);

        public void UpdateStaff(Staff staff) => _staffRepo.UpdateStaff(staff);

    }
}
