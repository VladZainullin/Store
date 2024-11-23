using Application.Contracts.Features.Products.Commands.CreateProduct;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.CreateProduct;

internal sealed class CreateProductHandler(IDbContext context, TimeProvider timeProvider)
    : IRequestHandler<CreateProductCommand, CreateProductResponseDto>
{
    public async Task<CreateProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var createProductParameters = new CreateProductParameters
        {
            Title = request.BodyDto.Title,
            Description = request.BodyDto.Description,
            Quantity = request.BodyDto.Quantity,
            Cost = request.BodyDto.Cost,
            TimeProvider = timeProvider
        };

        var product = new Product(createProductParameters);
        
        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
        
        return new CreateProductResponseDto
        {
            ProductId = product.Id
        };
    }
}