using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public
{
    public class MyInvoicesQueryHandler : IRequestHandler<MyInvoicesQuery, OperationResult<PagedResult<InvoiceDto>>>
    {
        private readonly IUserProvider _userProvider;
        private readonly ApplicationDbContext _dbContext;

        public MyInvoicesQueryHandler(IUserProvider userProvider, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userProvider = userProvider;
        }

        public async Task<OperationResult<PagedResult<InvoiceDto>>> Handle(MyInvoicesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<InvoiceDto>>();

            var userId = _userProvider.UserId();
            if (userId == null)
            {
                response.AddError("User not found");
                return response;
            }

            response.Value = await _dbContext.Invoices
                .AsNoTracking()
                .Where(invoice => invoice.UserId == userId)
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
