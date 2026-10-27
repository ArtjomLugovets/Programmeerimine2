using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    internal class ListCarsQueryHandler : IRequestHandler<ListCarsQuery, OperationResult<PagedResult<CarDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListCarsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<CarDto>>> Handle(ListCarsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CarDto>>();
            response.Value = await _dbContext.Cars
                .Select(car => new CarDto
                {
                    Id = car.Id,
                    RegistrationNumber = car.RegistrationNumber,
                    CarModelId = car.CarModelId
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
