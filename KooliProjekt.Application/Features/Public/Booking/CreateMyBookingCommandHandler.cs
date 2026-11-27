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
using BookingEntity = KooliProjekt.Application.Data.Booking;

namespace KooliProjekt.Application.Features.Public.Bookings
{
    public class CreateMyBookingCommandHandler : IRequestHandler<CreateMyBookingCommand, OperationResult>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public CreateMyBookingCommandHandler(
            IUserProvider userProvider,
            ApplicationDbContext dbContext)
        {
            _userProvider = userProvider;
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(
            CreateMyBookingCommand request,
            CancellationToken cancellationToken)
        {
            var response = new OperationResult();

            var userId = _userProvider.UserId();

            if (userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            var userExists = await _dbContext.Users
                .AnyAsync(user => user.Id == userId, cancellationToken);

            if (!userExists)
            {
                response.AddError("User not found");
                return response;
            }

            var car = await _dbContext.Cars
                .FirstOrDefaultAsync(car => car.Id == request.CarId, cancellationToken);

            if (car == null)
            {
                response.AddError("Car not found");
                return response;
            }

            if (request.Started >= request.Finished)
            {
                response.AddError("Finish date must be later than start date.");
                return response;
            }

            if (request.Started < DateTime.Now)
            {
                response.AddError("Booking cannot start in the past.");
                return response;
            }

            var overlappingBooking = await _dbContext.Bookings
                .AnyAsync(booking =>
                    booking.CarId == request.CarId &&
                    booking.Started < request.Finished &&
                    request.Started < booking.Finished,
                    cancellationToken);

            if (overlappingBooking)
            {
                response.AddError("This car is already booked for the selected period.");
                return response;
            }

            var booking = new BookingEntity
            {
                Started = request.Started,
                Finished = request.Finished,
                StartKm = 0,
                FinishKm = 0,
                KmRate = 0.35m,
                HourlyRate = 8.50m,
                CarId = request.CarId,
                UserId = userId.Value
            };

            _dbContext.Bookings.Add(booking);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
