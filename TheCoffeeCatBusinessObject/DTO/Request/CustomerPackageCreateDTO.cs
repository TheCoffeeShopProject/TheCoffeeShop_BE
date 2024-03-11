using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CustomerPackageCreateDTO
    {
        [Required(ErrorMessage = " DateStart is required.")]
        public DateTime DateStart { get; set; }
        [Required(ErrorMessage = " DateEnd is required.")]
        public DateTime DateEnd { get; set; }
        [Required(ErrorMessage = " CustomerId is required.")]

        public Guid CustomerID { get; set; }
        [Required(ErrorMessage = " SubscriptionId is required.")]
        public Guid SubscriptionID { get; set; }
    }
}
