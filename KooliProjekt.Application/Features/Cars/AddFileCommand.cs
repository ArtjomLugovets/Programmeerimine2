using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KooliProjekt.Application.Features.Cars
{
    public class AddFileCommand : IRequest<OperationResult>
    {
        public int CarId { get; set; }
        public string FileName { get; set; }
        public Stream InputStream { get; set; }
    }
}
