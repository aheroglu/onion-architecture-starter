namespace Server.Application.Features.ProductFeatures.GetById;

public sealed record GetProductByIdQueryResult(
    string Id,
    string Name,
    decimal Price,
    int Stock,
    DateTime CreatedDate,
    DateTime? UpdatedDate);
