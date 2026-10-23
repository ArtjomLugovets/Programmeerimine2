using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.CarModels
{
    internal class GetCarModelsQueryHandler : IRequestHandler<GetCarModelsQuery, OperationResult<CarModel>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarModelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CarModel>> Handle(GetCarModelsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CarModel>();
            response.Value = await _dbContext.CarModels.
                FindAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
