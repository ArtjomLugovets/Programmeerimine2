using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    internal class GetInvoiceLineQueryHandler : IRequestHandler<GetInvoiceLineQuery, OperationResult<InvoiceLine>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetInvoiceLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<InvoiceLine>> Handle(GetInvoiceLineQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<InvoiceLine>();
            var invoiceLine = await _dbContext.InvoiceLines
                .FindAsync(request.Id, cancellationToken);
            response.Value = invoiceLine;
            return response;
        }
    }
}
