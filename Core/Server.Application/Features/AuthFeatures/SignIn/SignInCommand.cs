using MediatR;
using Server.Domain.Dtos;

namespace Server.Application.Features.AuthFeatures.SignIn;

public sealed record SignInCommand(
    string Email,
    string Password) : IRequest<Result<AppUserDto>>;
