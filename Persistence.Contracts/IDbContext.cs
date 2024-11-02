using Domain.Entities.Carts;
using Domain.Entities.Categories;
using Domain.Entities.ProductInCarts;
using Domain.Entities.Products;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Category> Categories { get; }
    
    IDbSet<Product> Products { get; }
    
    IDbSet<Cart> Carts { get; }
    
    IDbSet<ProductInCart> ProductInCarts { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}