using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    public class SaveInvoiceLineCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public decimal LineItem { get; set; }
        public decimal Price { get; set; }
        public int Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int BookingId { get; set; }
    }
}
