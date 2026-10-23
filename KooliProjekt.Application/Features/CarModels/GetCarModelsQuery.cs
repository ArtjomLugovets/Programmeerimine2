using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CarModels
{
    public class GetCarModelsQuery : IRequest<OperationResult<CarModel>>
    {
        public int Id { get; set; }
    }
}
