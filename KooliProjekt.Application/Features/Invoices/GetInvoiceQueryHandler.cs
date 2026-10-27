using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Invoices
{
    internal class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, OperationResult<InvoiceDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetInvoiceQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<InvoiceDto>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<InvoiceDto>();
            response.Value = await _dbContext.Invoices
                .Where(invoice => invoice.Id == request.Id)
                .Select(invoice => new InvoiceDto
                {
                    Id = invoice.Id,
                    InvoiceDate = invoice.InvoiceDate,
                    Duedate = invoice.Duedate,
                    UserId = invoice.UserId,
                    IsPaid = invoice.IsPaid
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
