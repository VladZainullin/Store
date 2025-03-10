using Domain.Entities.MeasurementUnits.Parameters;
using EntityFrameworkCore.Projectables;

namespace Domain.Entities.MeasurementUnits;

public sealed class MeasurementUnit
{
    private Guid _id = Guid.CreateVersion7();

    private string _shortTitle = default!;
    private string _fullTitle = default!;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;

    private MeasurementUnit()
    {
    }
    
    public MeasurementUnit(CreateMeasurementUnitParameters parameters) : this()
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

    public Guid Id => _id;
    
    public string ShortTitle => _shortTitle;
    public string FullTitle => _fullTitle;
    
    public DateTimeOffset CreatedAt => _createdAt;
    public DateTimeOffset UpdatedAt => _updatedAt;
    public DateTimeOffset? RemovedAt => _removedAt;
    
    [Projectable]
    public bool IsRemoved => RemovedAt != default;

    public void SetShortTitle(SetShortTitleForMeasurementUnitParameters parameters)
    {
        _shortTitle = parameters.ShortTitle.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetFullTitle(SetFullTitleForMeasurementUnitParameters parameters)
    {
        _fullTitle = parameters.FullTitle.Trim();
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