using Domain.Entities.Characteristics.Parameters;
using Domain.Entities.ProductCharacteristics;
using Domain.Entities.ProductCharacteristics.Parameters;
using EntityFrameworkCore.Projectables;

namespace Domain.Entities.Characteristics;

public sealed class Characteristic
{
    private Guid _id = Guid.CreateVersion7();
    private string _title = default!;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    
    private DateTimeOffset? _removedAt;

    private List<ProductCharacteristic> _products = [];
    
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
    
    [Projectable]
    public bool IsRemoved => RemovedAt != default;
    
    public IReadOnlyList<ProductCharacteristic> Products => _products.AsReadOnly();

    public void SetTitle(SetTitleForCharacteristicParameters parameters)
    {
        _title = parameters.Title.Trim();
        _updatedAt = DateTimeOffset.UtcNow;
    }

    public void Remove(RemoveCharacteristicParameters parameters)
    {
        if (IsRemoved) return;

        foreach (var product in _products)
        {
            product.Remove(new RemoveProductCharacteristicParameters
            {
                TimeProvider = parameters.TimeProvider
            });
        }
        
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreCharacteristicParameters parameters)
    {
        if (!IsRemoved) return;
        
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}