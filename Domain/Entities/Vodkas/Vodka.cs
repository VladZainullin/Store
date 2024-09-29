using Domain.Entities.VodkaPositions;
using Domain.Entities.Vodkas.Parameters;

namespace Domain.Entities.Vodkas;

public sealed class Vodka
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;

    private readonly List<VodkaPosition> _positions = []; 

    private Vodka()
    {
    }

    public Vodka(CreateVodkaParameters parameters) : this()
    {
        SetTitle(new SetVodkaTitleParameters
        {
            Title = parameters.Title
        });
        
        SetDescription(new SetVodkaDescriptionParameters
        {
            Description = parameters.Description
        });
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetVodkaTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
    }
    
    public string Description => _description;

    public void SetDescription(SetVodkaDescriptionParameters parameters)
    {
        _description = parameters.Description.Trim();
    }

    public IReadOnlyCollection<VodkaPosition> Positions => _positions.AsReadOnly();
}