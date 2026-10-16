using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Users
{
    public class GetUserQuery : IRequest<KooliProjekt.Application.Data.User>
    {
        public int Id { get; set; }
    }
}
