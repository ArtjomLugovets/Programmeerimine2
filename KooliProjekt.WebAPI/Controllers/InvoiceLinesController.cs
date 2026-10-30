using KooliProjekt.Application.Features.InvoiceLines;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class InvoiceLinesController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public InvoiceLinesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var query = new GetInvoiceLineQuery { Id = id };
            var invoiceLine = await _mediator.Send(query);
            if (invoiceLine == null)
            {
                return NotFound();
            }
            return Json(invoiceLine);
        }
        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListInvoiceLinesQuery
            {
                Page = page,
                PageSize = pageSize
            };

            var invoiceLines = await _mediator.Send(query);
            return Json(invoiceLines);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(SaveInvoiceLineCommand command)
        {
            var result = await _mediator.Send(command);
            return Json(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInvoiceLineCommand command)
        {
            var result = await _mediator.Send(command);
            return Json(result);
        }
    }
}
