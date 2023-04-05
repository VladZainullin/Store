namespace Store.Domain.Entities;

public sealed class ProductDescription
{
    private ProductDescription(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator ProductDescription(string value)
    {
        return new ProductDescription(value);
    }
}