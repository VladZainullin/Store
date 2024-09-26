using Domain.Entities.Parameters;

namespace Domain.Entities;

public sealed class Vodka
{
    private string _title = default!;
    private string _description = default!;
    
    private Vodka()
    {
    }

    public Vodka(CreateVodkaParameters parameters) : this()
    {
        SetTitle(new SetVodkaTitleParameters
        {
            Title = parameters.Title
        });
        
        SetTitle(new SetVodkaDescriptionParameters
        {
            Description = parameters.Description
        });
    }

    public string Title => _title;

    public void SetTitle(SetVodkaTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
    }
    
    public string Description => _description;

    public void SetTitle(SetVodkaDescriptionParameters parameters)
    {
        _description = parameters.Description.Trim();
    }
}