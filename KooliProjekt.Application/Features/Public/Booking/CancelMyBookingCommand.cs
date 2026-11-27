using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.Booking
{
    public class CancelMyBookingCommand : IRequest<OperationResult<MyBooking>>
    {
        public int Id { get; set; }
    }
}
