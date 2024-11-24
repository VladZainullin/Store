using Domain.Entities.MeasurementUnits;
using Domain.Entities.MeasurementUnitValues.Parameters;

namespace Domain.Entities.MeasurementUnitValues;

public sealed class MeasurementUnitValue
{
    private Guid _id = Guid.NewGuid();

    private string _value = default!;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;

    private MeasurementUnit _measurementUnit = default!;
    
    public MeasurementUnitValue(CreateMeasurementUnitValueParameters parameters)
    {
        SetValue(new SetValueForMeasurementUnitValueParameters
        {
            Value = parameters.Value,
            TimeProvider = parameters.TimeProvider
        });
        
        SetMeasurementUnit(new SetMeasurementUnitForMeasurementUnitValueParameters
        {
            MeasurementUnit = parameters.MeasurementUnit,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public string Value => _value;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;
    
    public bool IsRemoved => _removedAt != default;
    
    public MeasurementUnit MeasurementUnit => _measurementUnit;

    public void Remove(RemoveMeasurementUnitValueParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreMeasurementUnitValueParameters parameters)
    {
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetValue(SetValueForMeasurementUnitValueParameters parameters)
    {
        _value = parameters.Value.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetMeasurementUnit(SetMeasurementUnitForMeasurementUnitValueParameters parameters)
    {
        _measurementUnit = parameters.MeasurementUnit;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}