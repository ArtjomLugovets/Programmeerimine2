using KooliProjekt.Application.Features.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class CarsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
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
            var query = new GetCarQuery { Id = id };
            var car = await _mediator.Send(query);
            if (car == null)
            {
                return NotFound();
            }
            return Json(car);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var query = new ListCarsQuery();
            var cars = await _mediator.Send(query);
            return Json(cars);
        }
    }
}
