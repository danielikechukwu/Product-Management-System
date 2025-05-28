using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Data;
using ProductManagementSystem.DTOs;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            try
            {
                List<Product> products = await _context.Products
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .ToListAsync();

                if (products.Count <= 0)
                {
                    return NotFound("Product list could not be located");
                }

                List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("GetProductById/{Id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById([FromRoute] int Id)
        {
            try
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .Include(p => p.Id)
                    .FirstOrDefaultAsync(p => p.Id == Id);

                if(product == null)
                {
                    return NotFound($"No product with {Id} found");
                }

                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);

                return Ok(productDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error occurred: {ex.Message}");
            }
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Product product = _mapper.Map<Product>(productCreateDTO);

                await _context.Products.AddAsync(product);

                await _context.SaveChangesAsync();

                // Retrieve and assign Category (if applicable)
                product.Category = await _context.Categories.FirstOrDefaultAsync(ctg => ctg.CategoryId == product.CategoryId);

                var productDTO = _mapper.Map<ProductDTO>(product);

                return Ok(productDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }
    }
}
