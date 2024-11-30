using Domain.Entities.Characteristics;
using Domain.Entities.ProductCharacteristics.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.ProductCharacteristics;

public sealed class ProductCharacteristic
{
    private Guid _id = Guid.CreateVersion7();
    
    private string _value = default!;

    private Product _product = default!;
    private Characteristic _characteristic = default!;
    
    

    private DateTimeOffset _createdAt;
    
    private DateTimeOffset _updatedAt;
    
    private DateTimeOffset? _removedAt;

    private ProductCharacteristic()
    {
    }

    public ProductCharacteristic(CreateProductCharacteristicParameters parameters) : this()
    {
        SetProduct(new SetProductForProductCharacteristicParameters
        {
            Product = parameters.Product,
            TimeProvider = parameters.TimeProvider
        });
        
        SetCharacteristic(new SetCharacteristicForProductCharacteristicParameters
        {
            Characteristic = parameters.Characteristic,
            TimeProvider = parameters.TimeProvider,
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public Guid Id => _id;
    
    public string Value => _value;
    
    public Product Product => _product;
    
    public Characteristic Characteristic => _characteristic;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;

    public bool IsRemoved => _removedAt != default;

    public void SetValue(SetValueForProductCharacteristicParameters parameters)
    {
        _value = parameters.Value.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetProduct(SetProductForProductCharacteristicParameters parameters)
    {
        _product = parameters.Product;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetCharacteristic(SetCharacteristicForProductCharacteristicParameters parameters)
    {
        _characteristic = parameters.Characteristic;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Remove(RemoveProductCharacteristicParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreProductCharacteristicParameters parameters)
    {
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}