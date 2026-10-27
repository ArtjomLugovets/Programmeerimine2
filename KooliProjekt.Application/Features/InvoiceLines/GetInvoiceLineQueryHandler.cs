using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    internal class GetInvoiceLineQueryHandler : IRequestHandler<GetInvoiceLineQuery, OperationResult<InvoiceLineDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetInvoiceLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<InvoiceLineDto>> Handle(GetInvoiceLineQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<InvoiceLineDto>();
            response.Value = await _dbContext.InvoiceLines
                .Where(invoiceLine => invoiceLine.Id == request.Id)
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
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
