using System.Web.Mvc;

namespace Framework.WebApiExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetNumber(int input)
        {
            return $"Route is HomeController.GetNumber(({nameof(input)})";
        }

        public string GetEmail(string email)
        {
            return $"Route is HomeController.GetEmail(({nameof(email)})";
        }

        [Route("Attr/{number:range(0,2147483647)}")]
        public string GetNumberAttributeRoute(int number)
        {
            return $"Route is HomeController.Get({nameof(number)})";
        }

        [Route("Attr/{email:Email}")]
        public string GetEmailAttributeRoute(string email)
        {
            return $"Route is HomeController.Get({nameof(email)})";
        }
    }
}