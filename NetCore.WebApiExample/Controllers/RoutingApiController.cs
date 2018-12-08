using Microsoft.AspNetCore.Mvc;

namespace NetCore.WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutingApiController : ControllerBase
    {
        [HttpGet]
        [Route("{email:Email}")]
        public IActionResult Get(string email)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(email)})");
        }        

        [HttpGet]
        [Route("{validPositiveInt32Value:range(0,2147483647)}")]
        public IActionResult Get(int validPositiveInt32Value)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(validPositiveInt32Value)}");
        }

        [HttpGet]
        [Route("{inputMatchingRegex:regex(^(.+)(_)(.+)$)}")]
        public IActionResult GetByRegex(string inputMatchingtRegexForValueContainingUnderscore)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(inputMatchingtRegexForValueContainingUnderscore)})");
        }
    }
}