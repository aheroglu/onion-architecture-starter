using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.AuthFeatures.SignUp;

internal sealed class SignUpCommandHandler(
    UserManager<AppUser> userManager, IMapper mapper) : IRequestHandler<SignUpCommand, Result<AppUserDto>>
{
    public async Task<Result<AppUserDto>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        AppUser user = new()
        {
            UserName = request.UserName,
            Email = request.Email
        };

        await userManager
            .CreateAsync(user, request.Password);

        return new("User created successfully", null, mapper.Map<AppUserDto>(user));
    }
}
