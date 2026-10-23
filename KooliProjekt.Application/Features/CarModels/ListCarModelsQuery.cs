using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.CarModels
{
    public class ListCarModelsQuery : IRequest<OperationResult<PagedResult<CarModel>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
