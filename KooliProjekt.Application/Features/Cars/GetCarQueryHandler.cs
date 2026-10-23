using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    internal class GetCarQueryHandler : IRequestHandler<GetCarQuery, OperationResult<Car>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<Car>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<Car>();
            response.Value = await _dbContext.Cars
                .FindAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
