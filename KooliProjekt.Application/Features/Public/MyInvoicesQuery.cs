using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public
{
    public class MyInvoicesQuery : IRequest<OperationResult<PagedResult<InvoiceDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
