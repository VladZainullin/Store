namespace Domain.Categories.Entities.Products.Parameters;

public readonly struct SetProductPhotoParameters
{
    public required TimeProvider TimeProvider { get; init; }
}