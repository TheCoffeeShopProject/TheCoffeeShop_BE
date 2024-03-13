using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class AccountUpdateDTO
    {
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*#?&^_-]+$", ErrorMessage = "Password must contain at least one letter and one number.")]
        public string? Password { get; set; }
        public bool? Status { get; set; }
        public Guid? RoleID { get; set; }
    }
}
