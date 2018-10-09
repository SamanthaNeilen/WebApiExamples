using Microsoft.AspNetCore.Mvc;

namespace NetCore.WebApiExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{email:Email}")]
        public IActionResult Get(string email)
        {
            return Ok($"Route is HomeController.Get({nameof(email)})");
        }
    }
}
