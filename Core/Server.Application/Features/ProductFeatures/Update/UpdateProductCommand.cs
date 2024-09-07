using MediatR;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.Update;

public sealed record UpdateProductCommand(
    string Id,
    string Name,
    decimal Price,
    int Stock) : IRequest<Result<Product>>;
