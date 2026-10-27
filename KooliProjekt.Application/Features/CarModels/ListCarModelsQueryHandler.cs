using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.CarModels
{
    internal class ListCarModelsQueryHandler : IRequestHandler<ListCarModelsQuery, OperationResult<PagedResult<CarModelDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListCarModelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<CarModelDto>>> Handle(ListCarModelsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CarModelDto>>();
            response.Value = await _dbContext.CarModels
                .Select(carModel => new CarModelDto
                {
                    Id = carModel.Id,
                    Name = carModel.Name
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
