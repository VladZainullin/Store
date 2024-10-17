using Domain.Categories.Entities.Categories;

namespace Persistence.Contracts.DbSets.CategoryRepositories.Commands;

public readonly struct CreateCategoryInputData
{
    public required Category Category { get; init; }
}