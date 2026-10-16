using KooliProjekt.Application.Data;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.Users
{
    public class ListUsersQuery : IRequest<IEnumerable<KooliProjekt.Application.Data.User>>
    {
    }
}
