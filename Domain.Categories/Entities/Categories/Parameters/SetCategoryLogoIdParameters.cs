namespace Domain.Categories.Entities.Categories.Parameters;

public readonly struct SetCategoryLogoIdParameters
{
    public required Guid LogoId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}