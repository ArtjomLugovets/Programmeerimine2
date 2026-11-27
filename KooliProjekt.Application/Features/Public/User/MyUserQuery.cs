using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.User
{
    public class MyUserQuery : IRequest<OperationResult<UserDto>>
    {
    }
}
