namespace Domain.Entities.Categories.Parameters;

public readonly struct RemoveCategoryParameters
{
    public required TimeProvider TimeProvider { get; init; }
}