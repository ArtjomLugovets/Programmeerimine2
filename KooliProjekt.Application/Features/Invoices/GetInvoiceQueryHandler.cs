using KooliProjekt.Application.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Invoices
{
    internal class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, Invoice>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetInvoiceQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Invoice> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices.FindAsync(request.Id, cancellationToken);
        }
    }
}
