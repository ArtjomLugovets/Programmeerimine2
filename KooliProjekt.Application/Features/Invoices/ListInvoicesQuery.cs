using KooliProjekt.Application.Data;
using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features.Invoices
{
    public class ListInvoicesQuery : IRequest<IEnumerable<Invoice>>
    {
    }
}
