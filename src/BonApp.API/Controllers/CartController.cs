using BonApp.API.Helpers;
using BonApp.Application.Interfaces;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CartController : Controller
{
    private const string CartSessionKey = "Cart";
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    public CartController(IProductRepository productRepository, IProductService productService)
    {
        _productRepository = productRepository;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetCart()
    {
        var cart = HttpContext.Session.GetObject<List<CartItemDto>>(CartSessionKey) ?? new List<CartItemDto>();
        return Ok(cart);
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] CartItemDto item)
    {
        var cart = HttpContext.Session.GetObject<List<CartItemDto>>(CartSessionKey) ?? new List<CartItemDto>();

        var existing = cart.FirstOrDefault(c => c.ProductId == item.ProductId);
        if (existing != null)
        {
            existing.Quantity += item.Quantity;
        }
        else
        {
            // Optional: Lấy thêm thông tin từ DB để đảm bảo đúng tên & giá
            var product = await _productRepository.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);
            if (product == null) return NotFound("Product not found");

            cart.Add(new CartItemDto
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = item.Quantity
            });
        }

        HttpContext.Session.SetObject(CartSessionKey, cart);
        return Ok(cart);
    }
}
