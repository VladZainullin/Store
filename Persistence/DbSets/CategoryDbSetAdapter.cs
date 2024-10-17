using Domain.Categories.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.DbSets.Categories;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Persistence.DbSets;

internal sealed class CategoryDbSetAdapter(AppDbContext context) : 
    DbSetAdapter<Category>(context), 
    ICategoryDbSet
{
    public Task<Category> GetAsync(GetCategoryByIdInputData data, CancellationToken cancellationToken = default)
    {
        var queryable = context.Categories;

        if (data.AsTracking)
        {
            queryable.AsTracking();
        }
        else
        {
            queryable.AsNoTracking();
        }

        if (data.IncludeProducts)
        {
            queryable.Include(static c => c.Products);
        }
        
        return queryable
            .Where(c => c.Id == data.CategoryId)
            .SingleAsync(cancellationToken);
    }
}