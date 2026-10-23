using KooliProjekt.Application.Features.CarModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class CarModelsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CarModelsController(IMediator mediator)
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

            var query = new GetCarModelsQuery { Id = id };
            var carModel = await _mediator.Send(query);

            if (carModel == null)
            {
                return NotFound();
            }

            return Json(carModel);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListCarModelsQuery
            {
                Page = page,
                PageSize = pageSize
            };

            var carModels = await _mediator.Send(query);
            return Json(carModels);
        }
    }
}
