using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Invoices
{
    internal class ListInvoicesQueryHandler : IRequestHandler<ListInvoicesQuery, IEnumerable<Invoice>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListInvoicesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Invoice>> Handle(ListInvoicesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices.ToListAsync(cancellationToken);
        }
    }
}
