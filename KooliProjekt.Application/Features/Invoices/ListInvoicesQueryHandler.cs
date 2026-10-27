using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Invoices
{
    internal class ListInvoicesQueryHandler : IRequestHandler<ListInvoicesQuery, OperationResult<PagedResult<InvoiceDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListInvoicesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<InvoiceDto>>> Handle(ListInvoicesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<InvoiceDto>>();
            response.Value = await _dbContext.Invoices
                .Select(invoice => new InvoiceDto
                {
                    Id = invoice.Id,
                    InvoiceDate = invoice.InvoiceDate,
                    Duedate = invoice.Duedate,
                    UserId = invoice.UserId,
                    IsPaid = invoice.IsPaid
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
