namespace Domain.Entities.Categories.Parameters;

public sealed class CreateCategoryParameters
{
    public required string Title { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}