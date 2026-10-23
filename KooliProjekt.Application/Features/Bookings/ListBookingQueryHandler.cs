using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class ListBookingQueryHandler : IRequestHandler<ListBookingQuery, OperationResult<PagedResult<Booking>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListBookingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<Booking>>> Handle(ListBookingQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<Booking>>();
            response.Value = await _dbContext.Bookings
                .GetPagedAsync(request.Page, request.PageSize);
            return response;
        }
    }
}
