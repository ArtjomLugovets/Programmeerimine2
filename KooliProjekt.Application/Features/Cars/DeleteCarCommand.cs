using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteCarCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
