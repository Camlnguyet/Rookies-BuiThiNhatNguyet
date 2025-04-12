using BonApp.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace BonApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    // [HttpGet]
    // public IActionResult Get()
}
