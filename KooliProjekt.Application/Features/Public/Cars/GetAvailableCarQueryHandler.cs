using Azure;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public.Cars
{
    public class GetAvailableCarQueryHandler : IRequestHandler<GetAvailableCarQuery, OperationResult<AvailableCar>>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public GetAvailableCarQueryHandler(IUserProvider userProvider, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }

        public async Task<OperationResult<AvailableCar>> Handle(GetAvailableCarQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<AvailableCar>();

            var now = DateTime.Now;

            response.Value = await _dbContext.Cars
                .Where(car => car.Id == request.CarId &&
                    !car.Bookings.Any(booking =>
                        booking.Started <= now &&
                        booking.Finished > now))
                .Select(car => new AvailableCar
                {
                    CarId = car.Id,
                    RegistrationNumber = car.RegistrationNumber,
                    CarModelName = car.CarModel.Name
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (response.Value == null)
            {
                response.AddError("Car not found or is not available");
            }

            return response;
        }
    }
}
