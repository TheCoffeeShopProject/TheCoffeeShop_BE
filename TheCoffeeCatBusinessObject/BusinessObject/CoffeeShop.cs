using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.BusinessObject
{
    public class CoffeeShop
    {
        public Guid CoffeeID { get; set; }
        public string CoffeeName { get; set; }
        public string OpenTime { get; set; }

        public string CloseTime { get; set; }
      
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }

        public List<Staff> Staffs { get; set; }

        public List<Cat> Cats { get; set; }


        public List<Table> Tables { get; set; }
        public List<Menu> Menus { get; set; }

   
        public List<Comment> Comments { get; set; }





    }
}
