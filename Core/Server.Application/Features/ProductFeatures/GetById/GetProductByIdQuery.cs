using MediatR;
using Server.Domain.Dtos;

namespace Server.Application.Features.ProductFeatures.GetById;

public sealed record GetProductByIdQuery(
    string Id) : IRequest<Result<GetProductByIdQueryResult>>;
