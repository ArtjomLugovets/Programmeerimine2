using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    internal class ListCarsQueryHandler : IRequestHandler<ListCarsQuery, OperationResult<PagedResult<Car>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListCarsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<Car>>> Handle(ListCarsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<Car>>();
            response.Value = await _dbContext.Cars
                .GetPagedAsync(request.Page, request.PageSize);
            return response;
        }
    }
}
