namespace Domain.Categories.Entities.Categories.Parameters;

public readonly struct SetCategoryParentParameters
{
    public required Category Parent { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}