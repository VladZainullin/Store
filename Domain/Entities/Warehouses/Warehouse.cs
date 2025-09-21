namespace Domain.Entities.Warehouses;

public sealed class Warehouse
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    
    public string Title { get; init; } = null!;

    public string Description { get; init; } = null!;
}