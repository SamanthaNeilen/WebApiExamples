using Microsoft.AspNetCore.Mvc;
using System;

namespace NetCore.WebApiExample.Controllers
{   
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
        public IActionResult Get(string email)
        {
            return Ok($"Route is HomeController.Get({nameof(email)})");
        }

        [HttpGet]
        [Route("customResponsetype")]
        [ProducesResponseType(200, Type = typeof(MyResponseType))]
        public IActionResult GetCustomResponseType()
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
