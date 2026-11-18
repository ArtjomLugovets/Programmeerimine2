using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesQueryHandler : IRequestHandler<ListFilesQuery, IReadOnlyList<StoredFileInfo>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileClient _fileClient;

        public ListFilesQueryHandler(ApplicationDbContext context, IFileClient fileClient)
        {
            _context = context;
            _fileClient = fileClient;
        }

        public async Task<IReadOnlyList<StoredFileInfo>> Handle(
            ListFilesQuery request,
            CancellationToken cancellationToken)
        {
            var carExists = await _context.Cars.AnyAsync(car => car.Id == request.CarId, cancellationToken);
            if (!carExists)
            {
                return new List<StoredFileInfo>();
            }

            return await _fileClient.List(FileStore.CarImages);
        }
    }
}
