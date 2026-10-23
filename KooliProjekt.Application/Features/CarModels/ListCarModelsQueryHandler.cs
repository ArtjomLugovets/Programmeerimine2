using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.CarModels
{
    internal class ListCarModelsQueryHandler : IRequestHandler<ListCarModelsQuery, OperationResult<PagedResult<CarModel>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListCarModelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<CarModel>>> Handle(ListCarModelsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CarModel>>();
            response.Value = await _dbContext.CarModels.GetPagedAsync(request.Page, request.PageSize);
            return response;
        }
    }
}
