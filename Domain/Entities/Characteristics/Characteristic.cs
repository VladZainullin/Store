using Domain.Entities.Characteristics.Parameters;

namespace Domain.Entities.Characteristics;

public sealed class Characteristic
{
    private Guid _id = Guid.CreateVersion7();
    private string _title = default!;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    
    private DateTimeOffset? _removedAt;
    
    private Characteristic()
    {
    }
    
    public Characteristic(CreateCharacteristicParameters parameters) : this()
    {
        SetTitle(new SetTitleForCharacteristicParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public string Title => _title;
    
    public DateTimeOffset CreatedAt => _createdAt;
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;
    
    public bool IsRemoved => _removedAt != default;

    public void SetTitle(SetTitleForCharacteristicParameters parameters)
    {
        _title = parameters.Title.Trim();
        _updatedAt = DateTimeOffset.UtcNow;
    }

    public void Remove(RemoveCharacteristicParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreCharacteristicParameters parameters)
    {
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}