using KooliProjekt.Application.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    internal class GetCarQueryHandler : IRequestHandler<GetCarQuery, Car>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Cars.FindAsync(request.Id, cancellationToken);
        }
    }
}
