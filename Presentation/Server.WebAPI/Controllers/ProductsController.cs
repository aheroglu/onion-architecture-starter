using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.ProductFeatures.Create;
using Server.Application.Features.ProductFeatures.Delete;
using Server.Application.Features.ProductFeatures.GetAll;
using Server.Application.Features.ProductFeatures.GetById;
using Server.Application.Features.ProductFeatures.Update;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public sealed class ProductsController : ApiController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await mediator.Send(new GetAllProductsQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetBy(string id, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(new DeleteProductCommand(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
