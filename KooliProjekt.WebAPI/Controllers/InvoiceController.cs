using KooliProjekt.Application.Features.Cars;
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

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListCarsQuery
            {
                Page = page,
                PageSize = pageSize
            };

            var invoices = await _mediator.Send(query);
            return Json(invoices);
        }
    }
}
