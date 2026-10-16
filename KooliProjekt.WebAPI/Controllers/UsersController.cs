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

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var query = new ListUsersQuery();
            var users = await _mediator.Send(query);
            return Json(users);
        }
    }
}
