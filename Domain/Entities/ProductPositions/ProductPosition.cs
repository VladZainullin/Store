using Domain.Entities.ProductPositions.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.ProductPositions;

public sealed class ProductPosition
{
    private Guid _id = Guid.NewGuid();

    private Guid _measurementUnitPositionId;

    private Guid _productId;
    private Product _product = default!;

    private ProductPosition()
    {
    }
    
    public ProductPosition(CreateProductPositionParameters parameters) : this()
    {
        SetVodka(new SetProductPositionVodkaParameters
        {
            Product = parameters.Product
        });
        
        SetMeasurementUnitId(new SetProductPositionMeasurementUnitPositionIdParameters
        {
            MeasurementUnitId = parameters.MeasurementUnitPositionId
        });
    }

    public Guid Id => _id;

    public Guid ProductId => _productId;
    
    public Product Product => _product;

    public void SetVodka(SetProductPositionVodkaParameters parameters)
    {
        _productId = parameters.Product.Id;
        _product = parameters.Product;
    }

    public Guid MeasurementUnitPositionId => _measurementUnitPositionId;
    
    public void SetMeasurementUnitId(SetProductPositionMeasurementUnitPositionIdParameters parameters)
    {
        _measurementUnitPositionId = parameters.MeasurementUnitId;
    }
}