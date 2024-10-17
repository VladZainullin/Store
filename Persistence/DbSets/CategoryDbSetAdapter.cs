using Domain.Categories.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.DbSets.CategoryRepositories;

namespace Persistence.DbSets;

internal sealed class CategoryDbSetAdapter(DbContext context) : 
    DbSetAdapter<Category>(context), 
    ICategoryDbSet
{
    
}