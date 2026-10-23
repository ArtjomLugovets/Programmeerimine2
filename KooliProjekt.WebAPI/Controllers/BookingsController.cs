using KooliProjekt.Application.Features.Bookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class BookingsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }

            var query = new GetBookingQuery { Id = id };
            var booking = await _mediator.Send(query);

            if (booking == null)
            {
                return NotFound();
            }

            return Json(booking);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListBookingQuery
            {
                Page = page,
                PageSize = pageSize
            };

            var bookings = await _mediator.Send(query);
            return Json(bookings);
        }
    }
}
