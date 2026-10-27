using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class ListBookingQueryHandler : IRequestHandler<ListBookingQuery, OperationResult<PagedResult<BookingDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListBookingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<BookingDto>>> Handle(ListBookingQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<BookingDto>>();
            response.Value = await _dbContext.Bookings
                .AsNoTracking()
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
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
