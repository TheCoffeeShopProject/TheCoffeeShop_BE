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
        public Guid CoffeeID { get; set; }
        public Guid CustomerID { get; set; }
    }
}
