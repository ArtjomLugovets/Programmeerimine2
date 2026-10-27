using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    internal class ListInvoiceLinesQueryHandler : IRequestHandler<ListInvoiceLinesQuery, OperationResult<PagedResult<InvoiceLineDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListInvoiceLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult<PagedResult<InvoiceLineDto>>> Handle(ListInvoiceLinesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<InvoiceLineDto>>();
            response.Value = await _dbContext.InvoiceLines
                .Select(invoiceLine => new InvoiceLineDto
                {
                    Id = invoiceLine.Id,
                    LineItem = invoiceLine.LineItem,
                    Price = invoiceLine.Price,
                    Unit = invoiceLine.Unit,
                    Quantity = invoiceLine.Quantity,
                    Total = invoiceLine.Total,
                    BookingId = invoiceLine.BookingId
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
