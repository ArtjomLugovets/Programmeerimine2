using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, OperationResult>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileClient _fileClient;

        public DeleteFileCommandHandler(ApplicationDbContext context, IFileClient fileClient)
        {
            _context = context;
            _fileClient = fileClient;
        }

        public async Task<OperationResult> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            await _fileClient.Delete(FileStore.CarImages, request.CarId);
            return new OperationResult();
        }
    }
}
