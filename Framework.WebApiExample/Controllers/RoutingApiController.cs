using System.Web.Http;

namespace Framework.WebApiExample.Controllers
{
    [RoutePrefix("api/routingapi")]
    public class RoutingApiController : ApiController
    {
        [HttpGet]
        [Route("{validPositiveInt32Value:range(0,2147483647)}")]
        public IHttpActionResult Get(int validPositiveInt32Value)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(validPositiveInt32Value)}");
        }

        [HttpGet]
        [Route("{valueMatchingRegex:regex(^(.+)(_)(.+)$)}")]
        public IHttpActionResult GetByRegex(string valueMatchingRegex)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(valueMatchingRegex)})");
        }

        [HttpGet]
        [Route("{email:Email}")]        
        public IHttpActionResult Get(string email)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(email)})");
        }
    }
}
