namespace Domain.Categories.Entities.Categories.Parameters;

public sealed class AddPhotoToCategoryProductParameters
{
    public required Guid ProductId { get; init; }
    
    public required Guid Photo { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}