using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class StaffDTO
    {
        public Guid StaffID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public Guid CoffeeID { get; set; }
        public Guid AccountID { get; set; }
    }
}
