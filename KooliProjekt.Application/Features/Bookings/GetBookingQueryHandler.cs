using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, OperationResult<Booking>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetBookingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<Booking>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<Booking>();
            response.Value = await _dbContext.Bookings
                .FindAsync(request.Id);
            return response;
        }
    }
}
