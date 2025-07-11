using System.ComponentModel.DataAnnotations;

namespace backend.Domain
{
    public class DrinkModel
    {
        [Required]
        public required string name { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public int price { get; set; }
    }
}
