namespace Server.Application.Features.ProductFeatures.GetAll;

public sealed record GetAllProductsQueryResult(
    string Id,
    string Name,
    decimal Price,
    int Stock,
    DateTime CreatedDate,
    DateTime? UpdatedDate);
