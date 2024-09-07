using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Services;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.AuthFeatures.SignIn;

internal sealed class SignInCommandHandler(
    UserManager<AppUser> userManager, IJwtService jwtService, IMapper mapper) : IRequestHandler<SignInCommand, Result<AppUserDto>>
{
    public async Task<Result<AppUserDto>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Email == request.Email, cancellationToken);

        if (user is null) return new(null, "User not found!", null);

        bool isPasswordCorrect = await userManager
            .CheckPasswordAsync(user, request.Password);

        if (isPasswordCorrect is false) return new(null, "Incorrect password!", null);

        string token = jwtService.GenerateToken(user);

        return new(token, null, mapper.Map<AppUserDto>(user));
    }
}
