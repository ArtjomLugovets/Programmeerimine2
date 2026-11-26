using KooliProjekt.Application.Features.Public;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class PublicController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PublicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("MyInvoices/{page}/{pageSize}")]
        public IActionResult Index(int page, int pageSize)
        {
            var query = new MyInvoicesQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = _mediator.Send(query).Result;
            return Result(result);
        }

        [HttpGet("MyInvoice/{id}")]
        public IActionResult Details(int id)
        {
            var query = new MyInvoiceQuery
            {
                Id = id
            };
            var result = _mediator.Send(query).Result;
            return Result(result);
        }

        [HttpPost("AddInvoice")]
        public IActionResult AddInvoice([FromBody] AddMyInvoiceCommand command)
        {
            var result = _mediator.Send(command).Result;
            return Result(result);
        }
    }
}
