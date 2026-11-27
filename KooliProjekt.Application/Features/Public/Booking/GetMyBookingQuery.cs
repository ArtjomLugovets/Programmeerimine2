using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.Booking
{
    public class GetMyBookingQuery : IRequest<OperationResult<MyBooking>>
    {
        public int BookingId { get; set; }
    }
}
