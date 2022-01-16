using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiShare.Application.Models.Trips;
using TaxiShare.Application.Requests.Admin.Commands;
using TaxiShare.Application.Requests.Admin.Queries;

namespace TaxiShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("trips")]
        [ProducesResponseType(typeof(List<TripItemVM>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTripsAsync()
        {
            var response = await mediator.Send(new GetAllTripsAdminQuery());
            if(response == null)
                return StatusCode(418);

            return Ok(response);
        }

        [HttpGet("trips/{guid}")]
        [ProducesResponseType(typeof(TripVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTripDetailsAsync(Guid guid)
        {
            var response = await mediator.Send(new GetTripAdminQuery(guid));
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost("trips/{guid}/remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ArchiveTripAsync(Guid guid)
        {
            var response = await mediator.Send(new ArchiveTripAdminCommand(guid));
            if (!response.Success)
                return StatusCode(response.HttpCode, response.Message);

            return Ok();
        }
    }
}
