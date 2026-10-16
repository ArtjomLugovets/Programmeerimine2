using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class ListBookingQueryHandler : IRequestHandler<ListBookingQuery, IEnumerable<Booking>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListBookingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Booking>> Handle(ListBookingQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookings.ToListAsync(cancellationToken);
        }
    }
}
