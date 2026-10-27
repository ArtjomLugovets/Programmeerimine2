using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Users
{
    internal class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, OperationResult<PagedResult<UserDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListUsersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<UserDto>>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<UserDto>>();
            response.Value = await _dbContext.Users
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
