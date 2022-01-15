using MediatR;
using TaxiShare.Domain.Entities;
using TaxiShare.Domain.Models.Trips;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Application.Requests.Trips.Commands
{
    public class CreateTripCommand : IRequest<GenericResponse<Guid>>
    {
        public CreateTripCommand(NewTripVM model)
        {
            Model = model;
        }

        public NewTripVM Model { get; set; }
    }


    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, GenericResponse<Guid>>
    {
        private readonly TaxiShareDbContext context;

        public CreateTripCommandHandler(TaxiShareDbContext context)
        {
            this.context = context;
        }

        public async Task<GenericResponse<Guid>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;
            var newTrip = new Trip(model.CreatorId, model.Title, model.DeparturePointAddress, model.ArrivalPointAddress, model.UserLimit, model.OverallCost);
            
            await context.AddAsync(newTrip);
            await context.SaveChangesAsync(cancellationToken);

            return new GenericResponse<Guid>(true, newTrip.Guid);
        }
    }
}
