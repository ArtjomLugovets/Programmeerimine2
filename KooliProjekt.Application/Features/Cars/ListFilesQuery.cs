using KooliProjekt.Application.Infrastructure.Files;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesQuery : IRequest<IReadOnlyList<StoredFileInfo>>
    {
        public int CarId { get; set; }
    }
}
