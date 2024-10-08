﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.WebAPI.Abstractions;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
    public readonly IMediator mediator;

    protected ApiController(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
