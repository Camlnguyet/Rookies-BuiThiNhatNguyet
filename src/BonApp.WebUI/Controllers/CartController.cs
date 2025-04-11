using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BonApp.WebUI.Controllers;

public class CartController : Controller
{
    private ICartRepository cartRepository { get; set; }
    public CartController()
    {
        cartRepository = new CartRepository();
    }
}
