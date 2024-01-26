using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject
{
    public class Drink
    {
        public Guid DrinkID { get; set; }
        public string DrinkName {  get; set; } 
        public double UnitPrice { get; set; }
        public bool Status { get; set; }
        public string Image {  get; set; }   

        public List<Menu> Menus { get; set; }
    }
}
