using AutoMapper;
using ProductManagementSystem.DTOs;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            // Mapping from ProductCreateDTO to Product (for creation)
            CreateMap<ProductCreateDTO, Product>()
                // Fixed value for CreatedDate
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                // Fixed value for CreatedBy
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => "Adim"))
                // Dynamic value based on Price
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Price > 500 ? "Premium" : "Standard"))
                // Dynamic value based on Stock
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.Stock > 0))
                // Null substitution for Description
                .ForMember(dest => dest.Description, opt => opt.NullSubstitute("No Description Available"))
                // Ignore complex type mapping for Category
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            // Mapping from Product to ProductGetDTO (for retrieving product details)
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "Uncategorized"))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("MM-dd-yyyy")))
                // Null substitution for Description
                .ForMember(dest => dest.Description, opt => opt.NullSubstitute("No Description Available"))
                // Availability based on Stock
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.Stock > 0));
                  
        }
    }
}
