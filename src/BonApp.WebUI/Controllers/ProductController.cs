using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BonApp.WebUI.Controllers;

public class ProductController : Controller
{
    private IProductRepository productRepository { get; set; }
    public ProductController()
    {
        // productRepository = new ProductRepository();
    }
}
