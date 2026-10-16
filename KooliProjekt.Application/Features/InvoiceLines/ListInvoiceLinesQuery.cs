using KooliProjekt.Application.Data;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    public class ListInvoiceLinesQuery : IRequest<IEnumerable<InvoiceLine>>
    {
    }
}
