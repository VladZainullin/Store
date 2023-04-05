namespace Store.Domain.ValueObjects;

public sealed class Id<T>
{
    public T Value { get; }

    private Id(T value)
    {
        Value = value;
    }

    public static implicit operator Id<T>(T value)
    {
        return new Id<T>(value);
    }
}