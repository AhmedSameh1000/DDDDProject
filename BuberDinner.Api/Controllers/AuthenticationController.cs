using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.LogIn;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    // [ErrorHandlingFilterAtterbute]
    public class AuthenticationController : AppControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest Request)
        {
            var RegisterCommand = _mapper.Map<RegisterCommand>(Request);
            var Response = await _mediator.Send(RegisterCommand);
            return NewResult(Response);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInrRequest Request)
        {
            var LogInQuey = _mapper.Map<LogInQuery>(Request);
            var Response = await _mediator.Send(LogInQuey);
            return NewResult(Response);
        }
    }
}
