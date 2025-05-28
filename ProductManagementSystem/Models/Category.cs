using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(50, ErrorMessage = "Category Name can't exceed 50 characters.")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
