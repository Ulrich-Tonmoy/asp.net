using System.ComponentModel.DataAnnotations;

namespace IMS.Data
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required]
        public string InventoryName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0")]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]
        public double Price { get; set; }
    }
}
