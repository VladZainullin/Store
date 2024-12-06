// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Addresses.Parameters;

public readonly struct SetCommentForAddressParameters
{
    public required string? Comment { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}