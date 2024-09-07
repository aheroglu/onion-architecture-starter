using MediatR;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.Create;

public record class CreateProductCommand(
    string Name,
    decimal Price,
    int Stock) : IRequest<Result<Product>>;
