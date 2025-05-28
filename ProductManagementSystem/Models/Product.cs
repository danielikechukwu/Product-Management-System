using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [MaxLength(100, ErrorMessage = "Product Name can't exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string? Description { get; set; } // Nullable for null substitution

        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; } // Fixed value

        public string CreatedBy { get; set; } // Fixed value "Admin"

        public int Stock { get; set; }

        public string? ProductType { get; set; } // Dynamic (e.g., Premium or Standard)

        public bool IsAvailable { get; set; } // Dynamic based on Stock quantity

        public int? CategoryId { get; set; }

        public Category? Category { get; set; } // Navigation property

    }
}
