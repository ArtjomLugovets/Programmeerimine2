using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Public.Booking;
using KooliProjekt.Application.Infrastructure;
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
    public class CompleteMyBookingCommandHandler : IRequestHandler<CompleteMyBookingCommand, OperationResult>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public CompleteMyBookingCommandHandler(
            IUserProvider userProvider,
            ApplicationDbContext dbContext)
        {
            _userProvider = userProvider;
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(
            CompleteMyBookingCommand request,
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

            var now = DateTime.Now;

            if (booking.Started > now || booking.Finished <= now)
            {
                response.AddError("Only active bookings can be completed.");
                return response;
            }

            if (request.FinishKm < booking.StartKm)
            {
                response.AddError("Finish mileage cannot be lower than start mileage.");
                return response;
            }

            booking.FinishKm = request.FinishKm;
            booking.Finished = now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
