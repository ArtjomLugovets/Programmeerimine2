using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.CarModels
{
    public class SaveCarModelCommandHandler : IRequestHandler<SaveCarModelCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCarModelCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveCarModelCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var carModel = new CarModel();
            
            if(request.Id == 0)
            {
                _dbContext.CarModels.Add(carModel);
            }
            else
            {
                carModel = await _dbContext.FindAsync<CarModel>(request.Id);
            }

            carModel.Name = request.Name;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
