using KooliProjekt.Application.Data;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.Bookings
{
    public class ListBookingQuery : IRequest<IEnumerable<Booking>>
    {
    }
}
