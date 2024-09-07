using AutoMapper;
using MediatR;
using Server.Application.Repositories;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.GetById;

internal sealed class GetProductByIdQueryHandler(
    IRepository<Product> repository, IMapper mapper) : IRequestHandler<GetProductByIdQuery, Result<GetProductByIdQueryResult>>
{
    public async Task<Result<GetProductByIdQueryResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = mapper
            .Map<GetProductByIdQueryResult>(await repository
            .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken));

        if (product is null) return new(null, "Product not found!", null);

        return new(null, null, product);
    }
}
