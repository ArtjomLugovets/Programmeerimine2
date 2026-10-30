using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Bookings
{
    public class DeleteBookingCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
