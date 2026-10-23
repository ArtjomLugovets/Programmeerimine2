using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Users
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, OperationResult<User>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<User>();
            response.Value = await _dbContext.Users
                .FindAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
