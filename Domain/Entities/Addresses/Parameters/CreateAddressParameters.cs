// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Addresses.Parameters;

public readonly struct CreateAddressParameters
{
    public required string? Title { get; init; }
    
    public required string City { get; init; }
    
    public required string Street { get; init; }

    public required string House { get; init; }

    public required string Root { get; init; }

    public required string Number { get; init; }

    public required string Comment { get; init; }

    public required Guid UserId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}