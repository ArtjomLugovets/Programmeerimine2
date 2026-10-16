using KooliProjekt.Application.Data;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListCarsQuery : IRequest<IEnumerable<Car>>
    {
    }
}
