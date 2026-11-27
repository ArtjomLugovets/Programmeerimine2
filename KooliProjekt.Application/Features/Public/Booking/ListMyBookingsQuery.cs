using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.Booking
{
    public class ListMyBookingsQuery : IRequest<OperationResult<PagedResult<MyBooking>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
