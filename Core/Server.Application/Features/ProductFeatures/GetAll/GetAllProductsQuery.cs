using MediatR;

namespace Server.Application.Features.ProductFeatures.GetAll;

public sealed class GetAllProductsQuery : IRequest<List<GetAllProductsQueryResult>>;
