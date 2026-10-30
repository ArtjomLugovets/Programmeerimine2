using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class SaveBookingCommandHandler : IRequestHandler<SaveBookingCommand, OperationResult>
    {
        public readonly ApplicationDbContext _dbContext;

        public SaveBookingCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveBookingCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var userExists = await _dbContext.Users
                .AnyAsync(user => user.Id == request.UserId);
            if (!userExists)
            {
                return result.AddPropertyError("UserId", "Cannot find user with ID " + request.UserId);
            }

            var carExists = await _dbContext.Cars
                .AnyAsync(car => car.Id == request.CarId);
            if (!carExists)
            {
                return result.AddPropertyError("CarId", "Cannot find car with ID " + request.CarId);
            }

            var booking = new Booking();

            if (request.Id == 0)
            {
                _dbContext.Bookings.Add(booking);
            }
            else
            {
                booking = await _dbContext.FindAsync<Booking>(request.Id);
            }

            booking.Started = request.Started;
            booking.Finished = request.Finished;
            booking.StartKm = request.StartKm;
            booking.FinishKm = request.FinishKm;
            booking.KmRate = request.KmRate;
            booking.HourlyRate = request.HourlyRate;
            booking.CarId = request.CarId;
            booking.UserId = request.UserId;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
