using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class CatResponseDTO
    {
        public string CatName { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public string? Image { get; set; }
    }
}
