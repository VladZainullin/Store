using Domain.Categories.Entities.Categories;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Persistence.Contracts.DbSets.Categories;

public interface ICategoryDbSet : IDbSet<Category>
{
    Task<Category> GetAsync(GetCategoryByIdInputData data, CancellationToken cancellationToken = default);
}