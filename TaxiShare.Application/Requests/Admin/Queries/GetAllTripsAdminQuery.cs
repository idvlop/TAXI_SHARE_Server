using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiShare.Domain.Models.Trips;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Application.Requests.Admin.Queries
{
    public class GetAllTripsAdminQuery : IRequest<List<TripItemVM>>
    {
        public GetAllTripsAdminQuery() { }
    }

    public class GetAllTripsAdminQueryHandler : IRequestHandler<GetAllTripsAdminQuery, List<TripItemVM>>
    {
        private readonly TaxiShareDbContext context;

        public GetAllTripsAdminQueryHandler(TaxiShareDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TripItemVM>> Handle(GetAllTripsAdminQuery request, CancellationToken cancellationToken)
        {
            var trips = await context.Trips
                .Include(x => x.Users)
                .Select(x => new TripItemVM(x))
                .ToListAsync(cancellationToken);

            return trips;
        }
    }
}
