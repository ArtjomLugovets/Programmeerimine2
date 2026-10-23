using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Invoices
{
    internal class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, OperationResult<Invoice>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetInvoiceQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<Invoice>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<Invoice>();
            response.Value = await _dbContext.Invoices
                .FindAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
