using Domain.Entities.Characteristics;
using Domain.Entities.Characteristics.Parameters;
using Domain.Entities.ProductCharacteristics.Parameters;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using EntityFrameworkCore.Projectables;

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
        
        SetValue(new SetValueForProductCharacteristicParameters
        {
            Value = parameters.Value,
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

    [Projectable]
    public bool IsRemoved => RemovedAt != default;

    public void SetValue(SetValueForProductCharacteristicParameters parameters)
    {
        if (IsRemoved) return;
        
        _value = parameters.Value.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetProduct(SetProductForProductCharacteristicParameters parameters)
    {
        if (IsRemoved) return;
        
        _product = parameters.Product;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetCharacteristic(SetCharacteristicForProductCharacteristicParameters parameters)
    {
        if (IsRemoved) return;
        
        _characteristic = parameters.Characteristic;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Remove(RemoveProductCharacteristicParameters parameters)
    {
        if (IsRemoved) return;
        
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreProductCharacteristicParameters parameters)
    {
        if (!IsRemoved) return;
        
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
        
        _product.Restore(new RestoreProductParameters
        {
            TimeProvider = parameters.TimeProvider
        });
        
        _characteristic.Restore(new RestoreCharacteristicParameters
        {
            TimeProvider = parameters.TimeProvider
        });
    }
}