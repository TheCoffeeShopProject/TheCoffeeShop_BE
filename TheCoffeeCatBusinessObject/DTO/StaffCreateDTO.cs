using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class StaffCreateDTO
    {
        public Guid StaffID { get; set; }

        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        [RegularExpression(@"^(?=.*[0-9])[-0-9]{10,15}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Coffee Shop is required.")]
        public Guid CoffeeID { get; set; }

        [Required(ErrorMessage = "Account is required.")]
        public Guid AccountID { get; set; }
    }
}
