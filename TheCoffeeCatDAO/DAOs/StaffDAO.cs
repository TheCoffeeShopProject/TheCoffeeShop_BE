using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class StaffDAO
    {
        private readonly TheCoffeeStoreDBContext _context;
        public StaffDAO()
        {
            _context = new TheCoffeeStoreDBContext();
        }

        public List<Staff> GetAllStaff()
        {
            try
            {
                return _context.Staffs.Include(c => c.CoffeeShop).Include(a => a.Account).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewStaff(Staff staff)
        {
            try
            {
                _context.Add(staff);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Staff GetStaffByID(Guid id)
        {
            try
            {
                var staff = _context.Staffs.Include(c => c.CoffeeShop)
                                           .Include(a => a.Account)
                                           .SingleOrDefault(c => c.StaffID == id);
                return staff;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStaff(Staff staff)
        {
            try
            {
                var a = _context.Staffs!.SingleOrDefault(c => c.StaffID == staff.StaffID);

                _context.Entry(a).CurrentValues.SetValues(staff);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
