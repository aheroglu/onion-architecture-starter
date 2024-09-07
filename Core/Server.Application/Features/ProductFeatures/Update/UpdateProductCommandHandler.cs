using AutoMapper;
using MediatR;
using Server.Application.Repositories;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.Update;

internal sealed class UpdateProductCommandHandler(
    IRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateProductCommand, Result<Product>>
{
    public async Task<Result<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = mapper
            .Map<Product>(request);

        if (product is null) return new(null, "Product not found!", product);

        repository
            .Update(product);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return new("Product was updated successfully", null, product);
    }
}
