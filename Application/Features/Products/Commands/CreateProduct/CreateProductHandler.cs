using Application.Contracts.Features.Products.Commands.CreateProduct;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.CreateProduct;

file sealed class CreateProductHandler(IDbContext context) : IRequestHandler<CreateProductCommand, CreateProductResponseDto>
{
    public async Task<CreateProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var oldVodka = await GetVodkaAsync(request.BodyDto.Title, cancellationToken);
        if (!ReferenceEquals(oldVodka, default))
            return new CreateProductResponseDto
            {
                VodkaId = oldVodka.Id
            };
        
        var parameters = new CreateProductParameters
        {
            Title = request.BodyDto.Title,
            Description = request.BodyDto.Description
        };
        var product = new Product(parameters);
            
        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
            
        return new CreateProductResponseDto
        {
            VodkaId = product.Id
        };

    }
    
    private Task<Product?> GetVodkaAsync(string manufacturerTitle, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .SingleOrDefaultAsync(m => m.Title == manufacturerTitle, cancellationToken);
    }
}