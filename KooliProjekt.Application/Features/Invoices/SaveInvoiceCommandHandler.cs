using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Invoices
{
    public class SaveInvoiceCommandHandler : IRequestHandler<SaveInvoiceCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveInvoiceCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveInvoiceCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var userExists = await _dbContext.Users
                .AnyAsync(user => user.Id == request.UserId);
            if (!userExists)
            {
                return result.AddPropertyError("UserId", "Cannot find user with ID " + request.UserId);
            }

            var invoice = new Invoice();

            if (request.Id == 0)
            {
                _dbContext.Invoices.Add(invoice);
            }
            else
            {
                invoice = await _dbContext.FindAsync<Invoice>(request.Id);
            }

            invoice.InvoiceDate = request.InvoiceDate;
            invoice.Duedate = request.Duedate;
            invoice.UserId = request.UserId;
            invoice.IsPaid = request.IsPaid;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
