using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Users
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, OperationResult<UserDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<UserDto>();
            response.Value = await _dbContext.Users
                .Where(user => user.Id == request.Id)
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
