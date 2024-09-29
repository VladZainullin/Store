using Domain.Entities.VodkaPositions.Parameters;
using Domain.Entities.Vodkas;

namespace Domain.Entities.VodkaPositions;

public sealed class VodkaPosition
{
    private Guid _id = Guid.NewGuid();

    private Guid _measurementUnitPositionId;

    private Guid _vodkaId;
    private Vodka _vodka = default!;

    private VodkaPosition()
    {
    }
    
    public VodkaPosition(CreateVodkaPositionParameters parameters) : this()
    {
        SetVodka(new SetVodkaPositionVodkaParameters
        {
            Vodka = parameters.Vodka
        });
        
        SetMeasurementUnitId(new SetVodkaPositionMeasurementUnitPositionIdParameters
        {
            MeasurementUnitId = parameters.MeasurementUnitPositionId
        });
    }

    public Guid Id => _id;

    public Guid VodkaId => _vodkaId;
    
    public Vodka Vodka => _vodka;

    public void SetVodka(SetVodkaPositionVodkaParameters parameters)
    {
        _vodkaId = parameters.Vodka.Id;
        _vodka = parameters.Vodka;
    }

    public Guid MeasurementUnitPositionId => _measurementUnitPositionId;
    
    public void SetMeasurementUnitId(SetVodkaPositionMeasurementUnitPositionIdParameters parameters)
    {
        _measurementUnitPositionId = parameters.MeasurementUnitId;
    }
}