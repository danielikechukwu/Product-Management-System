using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.DTOs
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "Product Name is required.")]
        [MaxLength(100, ErrorMessage = "Product Name can't exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string? Description { get; set; } // Nullable for null substitution

        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int? CategoryId { get; set; } // Category assignment
    }
}
