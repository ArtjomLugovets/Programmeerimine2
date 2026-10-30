using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Users
{
    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveUserCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var user = new User();

            if (request.Id == 0)
            {
                _dbContext.Users.Add(user);
            }
            else
            {
                user = await _dbContext.FindAsync<User>(request.Id);
            }

            user.Name = request.Name;
            user.Phone = request.Phone;
            user.Email = request.Email;
            user.IsAdmin = request.IsAdmin;
            user.Password = request.Password;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
