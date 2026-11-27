using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.Booking
{
    public class CreateMyBookingCommand : IRequest<OperationResult<MyBooking>>
    {
        public int CarId { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
    }
}
