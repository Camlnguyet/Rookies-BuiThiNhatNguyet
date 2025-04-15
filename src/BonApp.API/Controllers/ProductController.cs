using BonApp.Domain.Interfaces;
using BonApp.Domain.Interfaces.Service;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using BonApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BonApp.Domain.Entities;

namespace BonApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepository;
    private readonly ICsvProductImporter _csvImporter;
    private readonly IProductService _productService;

    public ProductController(IProductService productService,
    IProductRepository productRepository, ICsvProductImporter csvImporter, ILogger<ProductController> logger)
    {
        _csvImporter = csvImporter;
        _productRepository = productRepository;
        _productService = productService;
        _logger = logger;
    }

    // GET: api/products
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDetailDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductDetailDto>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();

        return Ok(products);
    }

    // Nhập product từ file csv
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
                await _productRepository.AddAsync(product);
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

    [HttpPost("test-add")]
    public async Task<IActionResult> TestAdd()
    {
        var p = new Product
        {
            // Id = 1,
            ProductName = "Test Product",
            CategoryId = 1,
            UpdatedAt = DateTimeOffset.UtcNow,
            DateUse = 12,
            Price = 9999,
            Status = "avalible",
            CreatedAt = DateTimeOffset.UtcNow
        };

        await _productRepository.AddAsync(p);
        await _productRepository.SaveChangesAsync();

        return Ok();
    }
}
