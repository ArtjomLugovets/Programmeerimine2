using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarCommandHandler : IRequestHandler<SaveCarCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCarCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveCarCommand request, CancellationToken cancellationToken)
        {
           var result = new OperationResult();

            var carModelExists = await _dbContext.CarModels
                .AnyAsync(carModel => carModel.Id == request.CarModelId);
            if (!carModelExists)
            {
                return result.AddPropertyError("CarModelId", "Cannot find car model with ID " + request.CarModelId);
            }

            var car = new Car();

            if (request.Id == 0)
            {
                _dbContext.Cars.Add(car);
            }
            else
            {
                car = await _dbContext.FindAsync<Car>(request.Id);
            }

            car.RegistrationNumber = request.RegistrationNumber;
            car.CarModelId = request.CarModelId;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
