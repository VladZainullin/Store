using Domain.Entities.VodkaPositions.Parameters;
using Domain.Entities.Vodkas;

namespace Domain.Entities.VodkaPositions;

public sealed class VodkaPosition
{
    private Guid _id = Guid.NewGuid();

    private Guid _volumeId;

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
        
        SetVolumeId(new SetVodkaPositionVolumeIdParameters
        {
            VolumeId = parameters.MeasurementUnitPositionId
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

    public Guid VolumeId => _volumeId;
    
    public void SetVolumeId(SetVodkaPositionVolumeIdParameters parameters)
    {
        _volumeId = parameters.VolumeId;
    }
}