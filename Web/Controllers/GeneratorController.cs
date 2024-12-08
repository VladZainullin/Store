using Bogus;
using Domain.Entities.Categories;
using Domain.Entities.Categories.Parameters;
using Domain.Entities.ProductInCategories.Parameters;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contracts;

namespace Web.Controllers;

[Route("api/v1/generator")]
public class GeneratorController : AppController
{
    [HttpPost]
    public async Task GenerateAsync(
        [FromServices] IDbContext context,
        [FromServices] TimeProvider timeProvider)
    {
        var createProductsParametersFaker = new Faker<CreateProductParameters>()
            .RuleFor(x => x.Title, f => f.Commerce.ProductName() + f.IndexGlobal)
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Quantity, f => f.Random.Number(1, 10))
            .RuleFor(x => x.Cost, f => f.Random.Number(500, 2000))
            .RuleFor(x => x.TimeProvider, timeProvider);
        var productsFaker = createProductsParametersFaker
            .GenerateLazy(100)
            .Select(p => new Product(p));

        context.Products.AddRange(productsFaker);

        var categoriesFaker = new Faker<CreateCategoryParameters>()
            .RuleFor(x => x.Title, f => f.Commerce.ProductName() + f.IndexGlobal)
            .RuleFor(x => x.TimeProvider, timeProvider);
        var categories = categoriesFaker
            .GenerateLazy(10)
            .Select(p => new Category(p));
        context.Categories.AddRange(categories);
        
        await context
            .SaveChangesAsync();

        Console.WriteLine();
    }
}