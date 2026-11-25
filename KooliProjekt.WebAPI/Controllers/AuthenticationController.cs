using KooliProjekt.Application.Authentication;
using KooliProjekt.Application.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand query)
        {
            var password = PasswordHelper.Hash(query.Password);
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
