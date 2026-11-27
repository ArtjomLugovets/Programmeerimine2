using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public.User
{
    public class UpdateMyUserCommandHandler : IRequestHandler<UpdateMyUserCommand, OperationResult>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public UpdateMyUserCommandHandler(
            IUserProvider userProvider,
            ApplicationDbContext dbContext)
        {
            _userProvider = userProvider;
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(
            UpdateMyUserCommand request,
            CancellationToken cancellationToken)
        {
            var response = new OperationResult();

            var userId = _userProvider.UserId();

            if (userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(user => user.Id == userId, cancellationToken);

            if (user == null)
            {
                response.AddError("User not found");
                return response;
            }

            user.Name = request.Name;
            user.Phone = request.Phone;
            user.Email = request.Email;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
