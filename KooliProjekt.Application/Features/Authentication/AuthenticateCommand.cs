using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Authentication
{
    public class AuthenticateCommand : IRequest<OperationResult<string>>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
