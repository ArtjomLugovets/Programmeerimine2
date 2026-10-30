using KooliProjekt.Application.Features.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
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
            var query = new GetUserQuery { Id = id };
            var user = await _mediator.Send(query);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListUsersQuery
            {
                Page = page,
                PageSize = pageSize
            };

            var users = await _mediator.Send(query);
            return Json(users);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(SaveUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Json(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Json(result);
        }
    }
}
