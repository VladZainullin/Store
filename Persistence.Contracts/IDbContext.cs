using Domain.Entities.Addresses;
using Domain.Entities.Carts;
using Domain.Entities.Categories;
using Domain.Entities.Characteristics;
using Domain.Entities.Orders;
using Domain.Entities.ProductInCarts;
using Domain.Entities.ProductInCategories;
using Domain.Entities.ProductInOrders;
using Domain.Entities.Products;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Category> Categories { get; }
    
    IDbSet<Product> Products { get; }
    
    IDbSet<Cart> Carts { get; }
    
    IDbSet<ProductInCart> ProductInCarts { get; }
    
    IDbSet<Order> Orders { get; }
    
    IDbSet<ProductInOrder> ProductInOrders { get; }
    
    IDbSet<ProductInCategory> ProductInCategories { get; }
    
    IDbSet<Characteristic> Characteristics { get; }
    
    IDbSet<Address> Addresses { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}