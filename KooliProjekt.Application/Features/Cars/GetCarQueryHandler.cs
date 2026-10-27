using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    internal class GetCarQueryHandler : IRequestHandler<GetCarQuery, OperationResult<CarDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CarDto>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CarDto>();
            response.Value = await _dbContext.Cars
                .Where(car => car.Id == request.Id)
                .Select(car => new CarDto
                {
                    Id = car.Id,
                    RegistrationNumber = car.RegistrationNumber,
                    CarModelId = car.CarModelId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
