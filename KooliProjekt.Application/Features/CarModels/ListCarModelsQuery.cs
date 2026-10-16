using KooliProjekt.Application.Data;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.CarModels
{
    public class ListCarModelsQuery : IRequest<IEnumerable<CarModel>>
    {
    }
}
