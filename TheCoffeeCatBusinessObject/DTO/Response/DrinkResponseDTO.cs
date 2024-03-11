using Microsoft.AspNetCore.Http;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class DrinkResponseDTO
    {
        public Guid DrinkID { get; set; }
        public string? DrinkName { get; set; }
        public double? UnitPrice { get; set; }
        public string? Image { get; set; }
    }
}

