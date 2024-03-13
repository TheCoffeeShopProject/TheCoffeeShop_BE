using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.ViewModels
{
    public class StaffVM
    {
        public Guid StaffID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string CoffeeName { get; set; }
        public string Email { get; set; }
    }
}
