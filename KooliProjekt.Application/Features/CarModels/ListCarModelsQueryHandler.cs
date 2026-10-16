using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.CarModels
{
    internal class ListCarModelsQueryHandler : IRequestHandler<ListCarModelsQuery, IEnumerable<CarModel>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListCarModelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CarModel>> Handle(ListCarModelsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.CarModels.ToListAsync(cancellationToken);
        }
    }
}
