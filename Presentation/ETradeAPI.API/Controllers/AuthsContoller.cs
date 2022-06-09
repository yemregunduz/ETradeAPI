using ETradeAPI.Application.Features.Authorizations.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsContoller : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthsContoller(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            var result = await _mediator.Send(registerCommand);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("passwordchange")]
        public async Task<IActionResult> PasswordChange([FromBody] PasswordChangeCommand passwordChangeCommand)
        {
            var result = await _mediator.Send(passwordChangeCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
