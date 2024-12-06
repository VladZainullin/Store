// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Addresses.Commands.CreateAddress;

public sealed class CreateAddressRequestBodyDto
{
    public required string? Title { get; init; }

    public required string City { get; init; }

    public required string Street { get; init; }

    public required string House { get; init; }

    public required string Root { get; init; }

    public required string Number { get; init; }

    public required string? Comment { get; init; }
}