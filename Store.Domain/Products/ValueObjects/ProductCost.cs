namespace Store.Domain.Products.ValueObjects;

public sealed class ProductCost
{
    private ProductCost(decimal value)
    {
        Value = value;
    }
    
    public decimal Value { get; }
    
    public static implicit operator ProductCost(decimal value)
    {
        return new ProductCost(value);
    }
}