using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NetCore.WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new [] {"value1", "value2"});
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Requested id: {id}");
        }

        [HttpPost]
        public IActionResult PostObjectParameter([FromBody] KeyValuePair<int,string> keyValuePair)
        {
            return Ok($"Posted values {keyValuePair}");
        }
        
        [HttpPost("{id}")]
        public IActionResult PostValueTypeParameter([FromRoute]int id, [FromBody] KeyValuePair<string,string> value)
        {
            return Ok($"Posted values {{ id: {id}, value: {value} }}");
        }
    }
}
