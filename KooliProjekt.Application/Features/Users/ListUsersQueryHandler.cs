using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Users
{
    internal class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, OperationResult<PagedResult<User>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListUsersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<User>>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<User>>();
            response.Value = await _dbContext.Users
                .GetPagedAsync(request.Page, request.PageSize);
            return response;
        }
    }
}
