using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, OperationResult>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileClient _fileClient;

        public AddFileCommandHandler(ApplicationDbContext context, IFileClient fileClient)
        {
            _context = context;
            _fileClient = fileClient;
        }

        public async Task<OperationResult> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var carExists = await _context.Cars.AnyAsync(car => car.Id == request.CarId, cancellationToken);

            if (!carExists)
            {
                result.AddError($"Car with id {request.CarId} was not found.");
                return result;
            }

            await _fileClient.Save(request.FileName, FileStore.CarImages, request.CarId, request.InputStream);

            return result;
        }
    }
}
