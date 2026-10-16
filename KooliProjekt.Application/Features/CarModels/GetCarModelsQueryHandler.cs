using KooliProjekt.Application.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.CarModels
{
    internal class GetCarModelsQueryHandler : IRequestHandler<GetCarModelsQuery, CarModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarModelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarModel> Handle(GetCarModelsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.CarModels.FindAsync(request.Id, cancellationToken);
        }
    }
}
