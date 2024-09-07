using MediatR;
using Server.Domain.Dtos;

namespace Server.Application.Features.AuthFeatures.SignUp;

public sealed record SignUpCommand(
    string UserName,
    string Email,
    string Password) : IRequest<Result<AppUserDto>>;
