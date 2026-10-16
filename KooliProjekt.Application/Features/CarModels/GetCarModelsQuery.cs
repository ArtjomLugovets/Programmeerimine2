using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.CarModels
{
    public class GetCarModelsQuery : IRequest<CarModel>
    {
        public int Id { get; set; }
    }
}
