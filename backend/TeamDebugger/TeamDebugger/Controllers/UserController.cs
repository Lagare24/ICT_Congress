using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TeamDebugger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("hello")]
        public async Task<IActionResult> Index()
        {
            return Ok("Hello World!");
        }
    }
}
