using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Public
{
    public class MyInvoiceQuery : IRequest<OperationResult<InvoiceDto>>
    {
        public int Id { get; set; }
    }
}
