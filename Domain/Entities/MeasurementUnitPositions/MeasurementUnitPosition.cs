using Domain.Entities.MeasurementUnitPositions.Parameters;
using Domain.Entities.MeasurementUnits;

namespace Domain.Entities.MeasurementUnitPositions;

public sealed class MeasurementUnitPosition
{
    private Guid _id = Guid.CreateVersion7();

    private string _value = default!;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;

    private MeasurementUnit _measurementUnit = default!;

    private MeasurementUnitPosition()
    {
    }
    
    public MeasurementUnitPosition(CreateMeasurementUnitPositionParameters parameters) : this()
    {
        SetValue(new SetValueForMeasurementUnitPositionParameters
        {
            Value = parameters.Value,
            TimeProvider = parameters.TimeProvider
        });
        
        SetMeasurementUnit(new SetMeasurementUnitForMeasurementUnitPositionParameters
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

    public void Remove(RemoveMeasurementUnitPositionParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreMeasurementUnitPositionParameters parameters)
    {
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetValue(SetValueForMeasurementUnitPositionParameters parameters)
    {
        _value = parameters.Value.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetMeasurementUnit(SetMeasurementUnitForMeasurementUnitPositionParameters parameters)
    {
        _measurementUnit = parameters.MeasurementUnit;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}