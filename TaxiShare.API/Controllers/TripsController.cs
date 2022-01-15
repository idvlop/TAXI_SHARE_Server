using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiShare.Application.Requests.Trips.Commands;
using TaxiShare.Domain.Models.Trips;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxiShare.Hub.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TripsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //// GET: api/<TripsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<TripsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TripsController>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateTripAsync([FromBody] NewTripVM newTrip)
        {
            var response = await mediator.Send(new CreateTripCommand(newTrip));
            if(!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Body);
        }

        //// PUT api/<TripsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TripsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
