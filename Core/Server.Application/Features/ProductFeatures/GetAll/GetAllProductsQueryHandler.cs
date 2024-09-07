using AutoMapper;
using MediatR;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.GetAll;

internal sealed class GetAllProductsQueryHandler(
    IRepository<Product> repository, IMapper mapper) : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResult>>
{
    public async Task<List<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = mapper
            .Map<List<GetAllProductsQueryResult>>(await repository
            .GetAllAsync(cancellationToken, true));

        return products;
    }
}