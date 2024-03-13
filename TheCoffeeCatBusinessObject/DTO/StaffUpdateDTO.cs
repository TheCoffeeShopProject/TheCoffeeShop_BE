using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class StaffUpdateDTO
    {
        public string? FullName { get; set; }
        [RegularExpression(@"^(?=.*[0-9])[-0-9]{10,15}$", ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? DOB { get; set; }
        public Guid? CoffeeID { get; set; }
        public Guid? AccountID { get; set; }
    }
}
