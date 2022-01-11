using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxiShare.Hub.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        // GET: api/<TripsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TripsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TripsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TripsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TripsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
