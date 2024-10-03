using Domain.Entities.ProductPositions.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.ProductPositions;

public sealed class ProductPosition
{
    private Guid _id = Guid.NewGuid();

    private Guid _measurementUnitPositionId;

    private Guid _productId;
    private Product _product = default!;
    
    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;

    private ProductPosition()
    {
    }
    
    public ProductPosition(CreateProductPositionParameters parameters) : this()
    {
        SetProduct(new SetProductPositionProductParameters
        {
            Product = parameters.Product,
            TimeProvider = parameters.TimeProvider
        });
        
        SetMeasurementUnitId(new SetProductPositionMeasurementUnitPositionIdParameters
        {
            MeasurementUnitId = parameters.MeasurementUnitPositionId,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public Guid ProductId => _productId;
    
    public Product Product => _product;

    public void SetProduct(SetProductPositionProductParameters parameters)
    {
        _productId = parameters.Product.Id;
        _product = parameters.Product;

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid MeasurementUnitPositionId => _measurementUnitPositionId;
    
    public void SetMeasurementUnitId(SetProductPositionMeasurementUnitPositionIdParameters parameters)
    {
        _measurementUnitPositionId = parameters.MeasurementUnitId;
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
}