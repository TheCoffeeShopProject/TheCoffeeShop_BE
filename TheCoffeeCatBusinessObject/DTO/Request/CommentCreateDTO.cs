using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CommentCreateDTO
    {    
        public string CommentText { get; set; }
        public DateTime CreateTime { get; set; }        
        public CoffeeShop CoffeeShop { get; set; }
        public Customer Customer { get; set; }
    }
}
