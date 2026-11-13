using KooliProjekt.Application.Infrastructure.Files;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesCommandHandler : IRequestHandler<ListFilesCommand, IReadOnlyList<StoredFileInfo>>
    {
        private readonly IFileClient _fileClient;

        public ListFilesCommandHandler(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public Task<IReadOnlyList<StoredFileInfo>> Handle(
            ListFilesCommand request,
            CancellationToken cancellationToken)
        {
            return _fileClient.List(FileStore.CarImages);
        }
    }
}
