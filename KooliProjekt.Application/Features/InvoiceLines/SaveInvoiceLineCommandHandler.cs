using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    public class SaveInvoiceLineCommandHandler : IRequestHandler<SaveInvoiceLineCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveInvoiceLineCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveInvoiceLineCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var bookingExists = await _dbContext.Bookings
                .AnyAsync(booking => booking.Id == request.BookingId);
            if (!bookingExists)
            {
                return result.AddPropertyError("BookingId", "Cannot find booking with ID " + request.BookingId);
            }

            var invoiceLine = new InvoiceLine();

            if (request.Id == 0)
            {
                _dbContext.InvoiceLines.Add(invoiceLine);
            }
            else
            {
                invoiceLine = await _dbContext.FindAsync<InvoiceLine>(request.Id);
            }

            invoiceLine.LineItem = request.LineItem;
            invoiceLine.Price = request.Price;
            invoiceLine.Unit = request.Unit;
            invoiceLine.Quantity = request.Quantity;
            invoiceLine.Total = request.Total;
            invoiceLine.BookingId = request.BookingId;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
