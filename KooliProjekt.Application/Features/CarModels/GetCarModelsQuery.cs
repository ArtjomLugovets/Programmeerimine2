using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CarModels
{
    public class GetCarModelsQuery : IRequest<OperationResult<CarModelDto>>
    {
        public int Id { get; set; }
    }
}
