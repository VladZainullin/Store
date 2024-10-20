namespace Domain.Categories.Entities.Products.Parameters;

public sealed class SetProductPhotoParameters
{
    public required Guid Photo { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}