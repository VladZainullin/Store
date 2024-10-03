using Application.Contracts.Features.Products.Commands.CreateProduct;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.CreateProduct;

file sealed class CreateProductHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<CreateProductCommand, CreateProductResponseDto>
{
    public async Task<CreateProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var oldProduct = await GetProductAsync(request.BodyDto.Title, cancellationToken);
        if (!ReferenceEquals(oldProduct, default))
            return new CreateProductResponseDto
            {
                ProductId = oldProduct.Id
            };
        
        var parameters = new CreateProductParameters
        {
            Title = request.BodyDto.Title,
            Description = request.BodyDto.Description,
            TimeProvider = timeProvider
        };
        var product = new Product(parameters);
            
        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
            
        return new CreateProductResponseDto
        {
            ProductId = product.Id
        };

    }
    
    private Task<Product?> GetProductAsync(string manufacturerTitle, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .SingleOrDefaultAsync(m => m.Title == manufacturerTitle, cancellationToken);
    }
}