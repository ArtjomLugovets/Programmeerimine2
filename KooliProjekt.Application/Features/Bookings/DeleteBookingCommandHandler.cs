using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Bookings
{
    internal class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteBookingCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Bookings
                .Where(booking => booking.Id == request.Id)
                .ExecuteDeleteAsync();

            return new OperationResult();
        }
    }
}
