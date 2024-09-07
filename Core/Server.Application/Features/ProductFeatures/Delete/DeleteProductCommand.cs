using MediatR;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.Delete;

public sealed record DeleteProductCommand(
    string Id) : IRequest<Result<Product>>;
