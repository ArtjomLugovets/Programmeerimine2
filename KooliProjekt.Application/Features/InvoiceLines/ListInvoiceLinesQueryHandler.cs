using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    internal class ListInvoiceLinesQueryHandler : IRequestHandler<ListInvoiceLinesQuery, IEnumerable<InvoiceLine>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListInvoiceLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<InvoiceLine>> Handle(ListInvoiceLinesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.InvoiceLines.ToListAsync(cancellationToken);
        }
    }
}
