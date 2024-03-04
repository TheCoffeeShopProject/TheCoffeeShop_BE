using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class CommentResponseDTO
    {
        
        public string CommentText { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public Guid CustomerID { get; set; }
    }
}
