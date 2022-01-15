using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiShare.Application.Models.Trips;
using TaxiShare.Application.Requests.Trips.Commands;

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

        // POST api/<TripsController>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTripAsync([FromBody] NewTripVM newTrip)
        {
            var response = await mediator.Send(new CreateTripCommand(newTrip));
            if(!response.Success)
                return StatusCode(response.HttpCode, response.Message);

            return Ok(response.Body);
        }

        //[HttpGet("{guid}/messages")]
        //[ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        //public async Task<ActionResult> GetTripMessagesAsync(Guid guid)
        //{
        //    return Ok();
        //}

    }
}
