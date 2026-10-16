using KooliProjekt.Application.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Users
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, KooliProjekt.Application.Data.User>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KooliProjekt.Application.Data.User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.FindAsync(request.Id, cancellationToken);
        }
    }
}
