namespace Domain.Categories.Entities.Products.Parameters;

public readonly struct SetProductPhotoParameters
{
    public required Guid Photo { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}