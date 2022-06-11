using Common.Security.Dtos;
using ETradeAPI.Application.Features.Authorizations.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var registerCommand = new RegisterCommand() { UserForRegisterDto = userForRegisterDto };
            var result = await _mediator.Send(registerCommand);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var loginCommand = new LoginCommand() { UserForLoginDto = userForLoginDto };
            var result = await _mediator.Send(loginCommand);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("passwordchange")]
        public async Task<IActionResult> PasswordChange([FromBody] UserForPasswordChangeDto userForPasswordChangeDto)
        {
            var passwordChangeCommand = new PasswordChangeCommand() { UserForPasswordChangeDto = userForPasswordChangeDto};
            var result = await _mediator.Send(passwordChangeCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
