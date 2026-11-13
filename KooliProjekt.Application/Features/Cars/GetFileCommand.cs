using System;
using System.Collections.Generic;
using System.Text;
using KooliProjekt.Application.Infrastructure.Files;
using MediatR;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetFileCommand : IRequest<StoredFile>
    {
        public int CarId { get; set; }
    }
}
