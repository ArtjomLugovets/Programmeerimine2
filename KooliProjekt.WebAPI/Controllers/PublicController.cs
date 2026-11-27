using KooliProjekt.Application.Features.Public.Booking;
using KooliProjekt.Application.Features.Public.Cars;
using KooliProjekt.Application.Features.Public.Invoices;
using KooliProjekt.Application.Features.Public.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("MyUser")]
        public IActionResult MyUser()
        {
            var query = new MyUserQuery();
            var result = _mediator.Send(query).Result;
            return Result(result);
        }

        [HttpPut("MyUser")]
        public IActionResult UpdateMyUser(UpdateMyUserCommand command)
        {
            var result = _mediator.Send(command).Result;
            return Result(result);
        }

        [HttpGet("AvailableCars/{page}/{pageSize}")]
        public IActionResult AvailableCars(int page, int pageSize)
        {
            var query = new ListAvailableCarsQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = _mediator.Send(query).Result;
            return Result(result);
        }

        [HttpGet("AvailableCar/{carId}")]
        public IActionResult AvailableCar(int carId)
        {
            var query = new GetAvailableCarQuery
            {
                CarId = carId
            };
            var result = _mediator.Send(query).Result;
            return Result(result);
        }

        [HttpGet("MyBookings/{page}/{pageSize}")]
        public IActionResult MyBookings(int page, int pageSize)
        {
            var query = new ListMyBookingsQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = _mediator.Send(query).Result;
            return Result(result);
        }

        [HttpGet("MyBooking/{bookingId}")]
        public IActionResult MyBooking(int bookingId)
        {
            var query = new GetMyBookingQuery
            {
                BookingId = bookingId
            };
            var result = _mediator.Send(query).Result;
            return Result(result);
        }

        [HttpPost("CreateMyBooking")]
        public async Task<IActionResult> CreateMyBooking([FromBody] CreateMyBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }

        [HttpDelete("CancelMyBooking/{bookingId}")]
        public async Task<IActionResult> CancelMyBooking(int bookingId)
        {
            var command = new CancelMyBookingCommand { Id = bookingId };
            var result = await _mediator.Send(command);
            return Result(result);
        }

        [HttpPut("CompleteMyBooking")]
        public async Task<IActionResult> CompleteMyBooking([FromBody] CompleteMyBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }
    }
}
