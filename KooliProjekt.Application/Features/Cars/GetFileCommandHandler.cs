using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetFileCommandHandler : IRequestHandler<GetFileCommand, StoredFile>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileClient _fileClient;

        public GetFileCommandHandler(ApplicationDbContext context, IFileClient fileClient)
        {
            _context = context;
            _fileClient = fileClient;
        }

        public async Task<StoredFile> Handle(GetFileCommand request, CancellationToken cancellationToken)
        {
            var carExists = await _context.Cars
                .AnyAsync(car => car.Id == request.CarId, cancellationToken);

            if (!carExists)
            {
                return null;
            }

            return await _fileClient.Get(
                FileStore.CarImages,
                request.CarId);
        }
    }
}
