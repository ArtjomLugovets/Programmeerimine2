using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    internal class ListInvoiceLinesQueryHandler : IRequestHandler<ListInvoiceLinesQuery, OperationResult<PagedResult<InvoiceLine>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListInvoiceLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<InvoiceLine>>> Handle(ListInvoiceLinesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<InvoiceLine>>();
            response.Value = await _dbContext.InvoiceLines.
                GetPagedAsync(request.Page, request.PageSize); ;
            return response ;
        }
    }
}
