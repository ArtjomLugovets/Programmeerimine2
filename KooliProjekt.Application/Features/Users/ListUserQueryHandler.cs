using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Users
{
    internal class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<KooliProjekt.Application.Data.User>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListUsersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<KooliProjekt.Application.Data.User>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.ToListAsync(cancellationToken);
        }
    }
}
