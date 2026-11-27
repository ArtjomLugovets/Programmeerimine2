using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public.User
{
    public class MyUserQueryHandler : IRequestHandler<MyUserQuery, OperationResult<UserDto>>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public MyUserQueryHandler(IUserProvider userProvider, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }
        public async Task<OperationResult<UserDto>> Handle(MyUserQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<UserDto>();

            var userId = _userProvider.UserId();
            if (userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            response.Value = await _dbContext.Users
                .AsNoTracking()
                .Where(user => user.Id == userId)
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin
                })
                .FirstOrDefaultAsync(cancellationToken);

            if(response.Value == null)
            {
                response.AddError("User not found");
            }

            return response;
        }
    }
}
