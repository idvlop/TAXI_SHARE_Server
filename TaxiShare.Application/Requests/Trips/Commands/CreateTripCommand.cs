using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiShare.Application.Models.Trips;
using TaxiShare.Domain.Entities;
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
            if (model == null)
                return new GenericResponse<Guid>(false, 400);

            var creator = await context.Users.FirstOrDefaultAsync(x => x.Id == model.CreatorId, cancellationToken);
            if (creator == null)
                return new GenericResponse<Guid>(false, 400);

            var newTrip = new Trip(model.CreatorId, model.Title, model.DeparturePointAddress, model.ArrivalPointAddress, model.UserLimit, model.OverallCost);
            newTrip.Users.Add(creator);

            await context.AddAsync(newTrip, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new GenericResponse<Guid>(true, newTrip.Guid);
        }
    }
}
