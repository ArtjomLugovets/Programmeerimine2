using KooliProjekt.Application.Infrastructure.Files;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesCommand : IRequest<IReadOnlyList<StoredFileInfo>>
    {
    }
}
