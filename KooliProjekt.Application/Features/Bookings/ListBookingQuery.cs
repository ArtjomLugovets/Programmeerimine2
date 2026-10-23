using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.Bookings
{
    public class ListBookingQuery : IRequest<OperationResult<PagedResult<Booking>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
