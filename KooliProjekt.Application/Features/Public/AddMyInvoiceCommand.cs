using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Public
{
    public class AddMyInvoiceCommand : IRequest<OperationResult<int?>>
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime Duedate { get; set; }
    }
}
