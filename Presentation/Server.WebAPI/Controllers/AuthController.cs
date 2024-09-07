using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.AuthFeatures.SignIn;
using Server.Application.Features.AuthFeatures.SignUp;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers;

public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }
}
