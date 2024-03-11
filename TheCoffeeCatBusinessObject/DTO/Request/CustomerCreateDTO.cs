using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CustomerCreateDTO
    {
        [Required(ErrorMessage = " Name is required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Number phone is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "AccountID is required.")]
        public Guid AccountID { get; set; }
    }
}
