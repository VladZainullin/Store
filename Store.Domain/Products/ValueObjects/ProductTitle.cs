namespace Store.Domain.Products.ValueObjects;

public sealed class ProductTitle
{
    public string Value { get; }

    private ProductTitle(string value)
    {
        Value = value;
    }

    public static implicit operator ProductTitle(string value)
    {
        return new ProductTitle(value);
    }
}