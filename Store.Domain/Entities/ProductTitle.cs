namespace Store.Domain.Entities;

public sealed class ProductTitle
{
    private ProductTitle(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator ProductTitle(string value)
    {
        return new ProductTitle(value);
    }
}