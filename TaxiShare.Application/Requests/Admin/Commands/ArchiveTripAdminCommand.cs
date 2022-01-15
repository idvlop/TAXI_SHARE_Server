using MediatR;
using Microsoft.EntityFrameworkCore;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Application.Requests.Admin.Commands
{
    public class ArchiveTripAdminCommand : IRequest<SimpleResponse>
    {
        public ArchiveTripAdminCommand(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid { get; set; }
    }

    public class ArchiveTripAdminCommandHandler : IRequestHandler<ArchiveTripAdminCommand, SimpleResponse>
    {
        private readonly TaxiShareDbContext context;

        public ArchiveTripAdminCommandHandler(TaxiShareDbContext context)
        {
            this.context = context;
        }

        public async Task<SimpleResponse> Handle(ArchiveTripAdminCommand request, CancellationToken cancellationToken)
        {
            var trip = await context.Trips.Where(x => x.Guid == request.Guid && x.InExistance).Include(x => x.Messeges).FirstOrDefaultAsync(cancellationToken);
            if (trip == null)
                return new SimpleResponse(false, "Trip was not found", 404);

            trip.Messeges.ForEach(x => x.InExistance = false);
            trip.InExistance = false;

            await context.SaveChangesAsync(cancellationToken);

            return new SimpleResponse(true);
        }
    }
}
