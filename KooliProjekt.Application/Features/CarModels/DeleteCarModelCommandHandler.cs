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

namespace KooliProjekt.Application.Features.CarModels
{
    internal class DeleteCarModelCommandHandler : IRequestHandler<DeleteCarModelCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteCarModelCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteCarModelCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.CarModels
                .Where(carModel => carModel.Id == request.Id)
                .ExecuteDeleteAsync();
            return new OperationResult();
        }
    }
}
