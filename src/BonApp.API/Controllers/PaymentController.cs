using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BonApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PaymentController : Controller
{
}
