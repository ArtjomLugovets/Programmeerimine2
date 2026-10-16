using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    internal class ListCarsQueryHandler : IRequestHandler<ListCarsQuery, IEnumerable<Car>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListCarsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Car>> Handle(ListCarsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Cars.ToListAsync(cancellationToken);
        }
    }
}
