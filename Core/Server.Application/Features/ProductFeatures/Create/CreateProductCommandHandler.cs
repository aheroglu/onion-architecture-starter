using AutoMapper;
using MediatR;
using Server.Application.Repositories;
using Server.Domain.Dtos;
using Server.Domain.Entities;

namespace Server.Application.Features.ProductFeatures.Create;

internal sealed class CreateProductCommandHandler(
    IRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateProductCommand, Result<Product>>
{
    public async Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = mapper
            .Map<Product>(request);

        await repository
            .AddAsync(product, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return new("Product added successfully", null, product);
    }
}
