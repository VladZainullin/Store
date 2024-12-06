using Domain.Entities.Addresses.Exceptions;
using Domain.Entities.Addresses.Parameters;
using EntityFrameworkCore.Projectables;

namespace Domain.Entities.Addresses;

public sealed class Address
{
    private Guid _id = Guid.CreateVersion7();

    private string? _title;
    
    private string _city = default!;
    private string _street = default!;
    private string _house = default!;
    private string _root = default!;
    private string _number = default!;

    private string? _comment;
    
    private Guid _clientId;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;
    
    private Address()
    {
    }
    
    public Address(CreateAddressParameters parameters) : this()
    {
        SetTitle(new SetTitleForAddressParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider,
        });
        
        SetCity(new SetCityForAddressParameters
        {
            City = parameters.City,
            TimeProvider = parameters.TimeProvider,
        });
        
        SetStreet(new SetStreetForAddressParameters
        {
            Street = parameters.Street,
            TimeProvider = parameters.TimeProvider,
        });
        
        SetHouse(new SetHouseForAddressParameters
        {
            House = parameters.House,
            TimeProvider = parameters.TimeProvider,
        });
        
        SetRoot(new SetRootForAddressParameters
        {
            Root = parameters.Root,
            TimeProvider = parameters.TimeProvider,
        });
        
        SetNumber(new SetNumberForAddressParameters
        {
            Number = parameters.Number,
            TimeProvider = parameters.TimeProvider,
        });
        
        
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public Guid Id => _id;
    
    public string? Title => _title;
    
    public string City => _city;
    
    public string Street => _street;
    
    public string House => _house;
    
    public string Root => _root;
    
    public string Number => _number;
    
    public string? Comment => _comment;
    
    public Guid ClientId => _clientId;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;
    
    [Projectable]
    public bool IsRemoved => _removedAt != default;

    public void SetTitle(SetTitleForAddressParameters parameters)
    {
        if (parameters.Title == default)
        {
            if (Title == default) return;
            
            _title = parameters.Title?.Trim();
            _updatedAt = parameters.TimeProvider.GetUtcNow();
            return;
        }
        
        if (parameters.Title == string.Empty) throw new SetEmptyTitleForAddressException();
        
        var trimmedTitle = parameters.Title.Trim();
        if (trimmedTitle == string.Empty) throw new SetWhiteSpacesTitleForAddressException();
        
        if (trimmedTitle.Length > 200) throw new SetMoreThanMaxLenghtTitleForAddressException();
        
        if (trimmedTitle == Title) return;
        
        _title = parameters.Title?.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetCity(SetCityForAddressParameters parameters)
    {
        _city = parameters.City.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetStreet(SetStreetForAddressParameters parameters)
    {
        _street = parameters.Street.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetHouse(SetHouseForAddressParameters parameters)
    {
        _house = parameters.House.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetRoot(SetRootForAddressParameters parameters)
    {
        _root = parameters.Root.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetNumber(SetNumberForAddressParameters parameters)
    {
        _number = parameters.Number.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetComment(SetCommentForAddressParameters parameters)
    {
        _comment = parameters.Comment?.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetUser(SetUserForAddressParameters parameters)
    {
        _clientId = parameters.ClientId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Remove(RemoveAddressParameters parameters)
    {
        if (IsRemoved) return;
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreAddressParameters parameters)
    {
        if (!IsRemoved) return;
        
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}