using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public
{
    public class MyInvoiceQueryHandler : IRequestHandler<MyInvoiceQuery, OperationResult<InvoiceDto>>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public MyInvoiceQueryHandler(IUserProvider userProvider, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }

        public async Task<OperationResult<InvoiceDto>> Handle(MyInvoiceQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<InvoiceDto>();
            var userId = _userProvider.UserId();

            if (userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            response.Value = await _dbContext.Invoices
                .AsNoTracking()
                .Where(invoice => invoice.UserId == userId && invoice.Id == request.Id)
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
