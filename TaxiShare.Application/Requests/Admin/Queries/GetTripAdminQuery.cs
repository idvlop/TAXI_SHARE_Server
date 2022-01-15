using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiShare.Domain.Models.Trips;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Application.Requests.Admin.Queries
{
    public class GetTripAdminQuery : IRequest<TripVM?>
    {
        public GetTripAdminQuery(Guid tripGuid)
        {
            TripGuid = tripGuid;
        }

        public Guid TripGuid { get; set; }
    }

    public class GetTripAdminQueryHandler : IRequestHandler<GetTripAdminQuery, TripVM?>
    {
        private readonly TaxiShareDbContext context;

        public GetTripAdminQueryHandler(TaxiShareDbContext context)
        {
            this.context = context;
        }

        public async Task<TripVM?> Handle(GetTripAdminQuery request, CancellationToken cancellationToken)
        {
            var trip = await context.Trips.Where(x => x.Guid == request.TripGuid).Include(x => x.Users).Include(x => x.Messeges).FirstOrDefaultAsync(cancellationToken);
            if (trip == null)
                return null;

            var response = new TripVM(trip);
            return response;
        }
    }
}
