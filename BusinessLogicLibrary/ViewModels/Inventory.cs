using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.ViewModels
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        public string InventoryName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]
        public double Price { get; set; }

        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
    }
}
