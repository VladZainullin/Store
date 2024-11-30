// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Categories.Parameters;

public readonly struct RestoreCategoryParameters
{
    public required TimeProvider TimeProvider { get; init; }
}