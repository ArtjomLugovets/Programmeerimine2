using KooliProjekt.Application.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    internal class GetInvoiceLineQueryHandler : IRequestHandler<GetInvoiceLineQuery, InvoiceLine>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetInvoiceLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InvoiceLine> Handle(GetInvoiceLineQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.InvoiceLines.FindAsync(request.Id, cancellationToken);
        }
    }
}
