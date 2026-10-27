using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, OperationResult<BookingDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetBookingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<BookingDto>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<BookingDto>();
            response.Value = await _dbContext.Bookings
                .AsNoTracking()
                .Where(booking => booking.Id == request.Id)
                .Select(booking => new BookingDto
                {
                    Id = booking.Id,
                    Started = booking.Started,
                    Finished = booking.Finished,
                    StartKm = booking.StartKm,
                    FinishKm = booking.FinishKm,
                    KmRate = booking.KmRate,
                    HourlyRate = booking.HourlyRate,
                    CarId = booking.CarId,
                    UserId = booking.UserId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
