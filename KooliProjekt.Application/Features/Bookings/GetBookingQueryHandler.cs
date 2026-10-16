using KooliProjekt.Application.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, Booking>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetBookingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookings.FindAsync(request.Id, cancellationToken);
        }
    }
}
