using Microsoft.AspNetCore.Mvc;

namespace NetCore.WebApiExample.Controllers
{
    [Route("api/RoutingApi")]
    [ApiController]
    [ApiVersion("2.0")]    
    public class RoutingApiV2Controller : ControllerBase
    {
        [HttpGet]
        [Route("{email:Email}")]
        public IActionResult Get(string email)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(email)}) (V2)");
        }

        [HttpGet]
        [Route("{validPositiveInt32Value:range(0,2147483647)}")]
        public IActionResult Get(int validPositiveInt32Value)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(validPositiveInt32Value)} (V2)");
        }
    }
}