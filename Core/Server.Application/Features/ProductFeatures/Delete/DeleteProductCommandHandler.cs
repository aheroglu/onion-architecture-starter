using MediatR;
using Server.Application.Repositories;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.Delete;

internal sealed class DeleteProductCommandHandler(
    IRepository<Product> repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, Result<Product>>
{
    public async Task<Result<Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await repository
            .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null) return new(null, "Product not found!", null);

        repository
            .Delete(product);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return new("Product was deleted successfully", null, product);
    }
}
