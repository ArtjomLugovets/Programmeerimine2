using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.CarModels
{
    internal class GetCarModelsQueryHandler : IRequestHandler<GetCarModelsQuery, OperationResult<CarModelDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarModelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CarModelDto>> Handle(GetCarModelsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CarModelDto>();
            response.Value = await _dbContext.CarModels
                .Where(carModel => carModel.Id == request.Id)
                .Select(carModel => new CarModelDto
                {
                    Id = carModel.Id,
                    Name = carModel.Name
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
