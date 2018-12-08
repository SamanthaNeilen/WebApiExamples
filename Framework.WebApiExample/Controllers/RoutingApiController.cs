using System;
using System.Web.Http;
using System.Web.Http.Description;

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

        /// <summary>
        /// This route has a XML comments description
        /// </summary>
        /// <remarks>
        /// This is a remark!
        /// </remarks>
        /// <param name="email">A valid email</param>
        /// <returns>Single line of text describing the route for the result</returns>
        [HttpGet]
        [Route("{email:Email}")]        
        public IHttpActionResult Get(string email)
        {
            return Ok($"Route is RoutingApiController.Get({nameof(email)})");
        }

        [HttpGet]
        [Route("customResponsetype")]
        [ResponseType(typeof(MyResponseType))]
        public IHttpActionResult GetCustomResponseType()
        {
            return Ok(new MyResponseType
            {
                Title = "SomeTitle",
                Data = "SomeData"
            });
        }

        public class MyResponseType
        {
            public string Title { get; set; }

            public string Data { get; set; }

            public int Number { get; set; }

            public DateTime Timestamp { get; set; }
        }
    }
}
