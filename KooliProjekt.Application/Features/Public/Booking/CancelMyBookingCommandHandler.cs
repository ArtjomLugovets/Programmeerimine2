using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Public.Booking;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public.Bookings
{
    public class CancelMyBookingCommandHandler : IRequestHandler<CancelMyBookingCommand, OperationResult>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public CancelMyBookingCommandHandler(
            IUserProvider userProvider,
            ApplicationDbContext dbContext)
        {
            _userProvider = userProvider;
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(
            CancelMyBookingCommand request,
            CancellationToken cancellationToken)
        {
            var response = new OperationResult();

            var userId = _userProvider.UserId();

            if (userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            var booking = await _dbContext.Bookings
                .FirstOrDefaultAsync(
                    booking => booking.Id == request.Id &&
                               booking.UserId == userId,
                    cancellationToken);

            if (booking == null)
            {
                response.AddError("Booking not found.");
                return response;
            }

            if (booking.Started <= DateTime.Now)
            {
                response.AddError("A booking cannot be cancelled after it has started.");
                return response;
            }

            _dbContext.Bookings.Remove(booking);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
