using Microsoft.AspNetCore.Http;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class DrinkResponseDTO
    {
        public string DrinkName { get; set; }
        public double UnitPrice { get; set; }
        public bool Status { get; set; }
        public IFormFile? Image { get; set; }
    }
}

