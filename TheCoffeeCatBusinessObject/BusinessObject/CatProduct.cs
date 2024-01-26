using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.BusinessObject
{
    public class CatProduct
    {
        public Guid CatProductID { get; set; }
        public string CatProductName { get; set; }
        public string CatProductType { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }

        public List<Menu> Menus { get; set; }
    }
}
