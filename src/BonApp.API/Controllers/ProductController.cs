using BonApp.Domain.Interfaces;
using BonApp.Domain.Interfaces.Service;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using BonApp.Domain.Entities;
using BonApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepository;
    private readonly ICsvProductImporter _csvImporter;
    private readonly IProductService _productService;
    private readonly ICategoryService categoryService;
    private readonly ICategoryRepository _categoryRepository;

    public ProductController(IProductService productService,
    IProductRepository productRepository, ICsvProductImporter csvImporter, ILogger<ProductController> logger,
    ICategoryService _categoryService, ICategoryRepository categoryRepository)
    {
        _csvImporter = csvImporter;
        _productRepository = productRepository;
        _productService = productService;
        _logger = logger;
        categoryService = _categoryService;
        _categoryRepository = categoryRepository;
    }

    // GET: api/products
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDetailDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductDetailDto>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();

        return Ok(products);
    }

    // GET: api/product/upload-csv
    [HttpPost("upload-csv")]
    // [ProducesResponseType(typeof(), StatusCodes.Status201Created)]
    public async Task<IActionResult> UploadCsvAsync([FromForm] CsvUploadFile dto)
    {

        if (dto.File == null || dto.File.Length == 0)
            return BadRequest("File is required");

        var products = await _csvImporter.ParseCsvAsync(dto.File);

        if (products == null || products.Count == 0)
            return BadRequest("CSV file is empty or invalid");
        foreach (var product in products)
        {
            try
            {
                await _productRepository.CreateAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm sản phẩm {product.ProductName}: {ex.Message}");
            }
            _logger.LogInformation("Thêm sản phẩm: {ProductName}", product.ProductName);
        }

        await _productRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducts), new { }, new { Count = products.Count, Message = "Products imported successfully" });
    }

    // POST api/product
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDto dto)
    {
        var product = await _productService.CreateProductAsync(dto);
        if (product == null)
        {
            return BadRequest("Product name already exists.");
        }
        return Ok(product);
    }

    // delete hard
    // DELETE api/product/:id
    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductListDto>> DeleteIdProduct(int id)
    {
        var product = await _productRepository.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return BadRequest("Not found");
        }
        _productRepository.Delete(product);
        await _productRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { }, new { product, Message = "Product deleted successfull." });
    }

    // GET: api/product/:id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailDto>> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return BadRequest("Not found");
        }
        return Ok(product);
        // chuyển đổi từ entity product sang dto product dtos
    }

    // PUT: api/product/:id
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDetailDto>> UpdateFullProduct(int id, [FromBody] ProductDetailDto dto)
    {
        //  Nếu tên để nguyên không chỉnh sửa thì nó có báo lỗi không?
        if (await _productService.IsProductAvailableAsync(dto.ProductName))
        {
            return BadRequest("Name after update is existed.");
        }
        var product = await _productRepository.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return BadRequest("Not found");
        }

        var category = await _categoryRepository.Categories.FirstOrDefaultAsync(c => c.CategoryName.ToLower().Trim() == dto.CategoryName.ToLower().Trim());
        if (category == null)
        {
            category = new Category
            {
                CategoryName = dto.CategoryName,
                Status = "availible"
            };
            _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();
        }
        product.ProductName = dto.ProductName;
        product.ProductDescription = dto.ProductDescription;
        product.Price = dto.Price;
        product.CategoryId = category.Id;
        product.DateProduce = dto.DateProduce;

        var result = new ProductDetailDto
        {
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            Price = product.Price,
            DateProduce = product.DateProduce,
            CategoryName = category.CategoryName
        };

        await _productRepository.SaveChangesAsync();
        return Ok(new { result, Message = "Product update successful" });
    }
    // [HttpPatch("update-product")]
}
