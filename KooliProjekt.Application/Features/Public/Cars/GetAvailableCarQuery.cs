using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.Cars
{
    public class GetAvailableCarQuery : IRequest<OperationResult<AvailableCar>>
    {
        public int CarId { get; set; }
    }
}
