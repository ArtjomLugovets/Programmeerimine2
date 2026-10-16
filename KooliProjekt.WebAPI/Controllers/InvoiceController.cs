using KooliProjekt.Application.Features.Invoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class InvoiceController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
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
            var query = new GetInvoiceQuery { Id = id };
            var invoice = await _mediator.Send(query);
            if (invoice == null)
            {
                return NotFound();
            }
            return Json(invoice);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var query = new ListInvoicesQuery();
            var invoices = await _mediator.Send(query);
            return Json(invoices);
        }
    }
}
