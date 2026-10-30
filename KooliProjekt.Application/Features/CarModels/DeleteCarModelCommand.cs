using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.CarModels
{
    public class DeleteCarModelCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
