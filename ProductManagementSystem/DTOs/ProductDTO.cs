namespace ProductManagementSystem.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
        public bool IsAvailable { get; set; }
        public string CategoryName { get; set; }
        public string CreatedDate { get; set; }
    }
}
