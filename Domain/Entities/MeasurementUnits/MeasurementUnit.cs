using Domain.Entities.MeasurementUnits.Parameters;

namespace Domain.Entities.MeasurementUnits;

public sealed class MeasurementUnit
{
    private Guid _id = Guid.NewGuid();

    private string _shortTitle = default!;
    private string _fullTitle = default!;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;
    
    public MeasurementUnit(CreateMeasurementUnitParameters parameters)
    {
        SetShortTitle(new SetShortTitleForMeasurementUnitParameters
        {
            ShortTitle = parameters.ShortTitle,
            TimeProvider = parameters.TimeProvider
        });
        
        SetFullTitle(new SetFullTitleForMeasurementUnitParameters
        {
            FullTitle = parameters.FullTitle,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetShortTitle(SetShortTitleForMeasurementUnitParameters parameters)
    {
        _shortTitle = parameters.ShortTitle;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetFullTitle(SetFullTitleForMeasurementUnitParameters parameters)
    {
        _fullTitle = parameters.FullTitle;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Remove(RemoveMeasurementUnitParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreMeasurementUnitParameters parameters)
    {
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}