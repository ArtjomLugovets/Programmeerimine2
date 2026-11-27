using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public.Booking
{
    public class GetMyBookingQueryHandler : IRequestHandler<GetMyBookingQuery, OperationResult<MyBooking>>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public GetMyBookingQueryHandler(
            IUserProvider userProvider,
            ApplicationDbContext dbContext)
        {
            _userProvider = userProvider;
            _dbContext = dbContext;
        }

        public async Task<OperationResult<MyBooking>> Handle(GetMyBookingQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<MyBooking>();
            var userId = _userProvider.UserId();

            if(userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            response.Value = await _dbContext.Bookings
                .AsNoTracking()
                .Where(booking => booking.Id == request.BookingId && booking.UserId == userId)
                .Select(booking => new MyBooking
                {
                    Id = booking.Id,
                    Started = booking.Started,
                    Finished = booking.Finished,
                    StartKm = booking.StartKm,
                    FinishKm = booking.FinishKm,
                    KmRate = booking.KmRate,
                    HourlyRate = booking.HourlyRate,
                    CarId = booking.CarId,
                    RegistrationNumber = booking.Car.RegistrationNumber,
                    CarModelName = booking.Car.CarModel.Name
                })
                .FirstOrDefaultAsync(cancellationToken);

            if(response.Value == null)
            {
                response.AddError("Booking not found");
            }

            return response;
        }
    }
}
