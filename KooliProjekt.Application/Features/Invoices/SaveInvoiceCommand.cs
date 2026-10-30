using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Invoices
{
    public class SaveInvoiceCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime Duedate { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
    }
}
