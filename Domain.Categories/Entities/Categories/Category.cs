using Domain.Categories.Entities.Categories.Parameters;

namespace Domain.Categories.Entities.Categories;

public sealed class Category
{
    private Guid _id = Guid.NewGuid();

    private string _title = default!;

    private Category? _parent;

    private readonly List<Category> _children = [];

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private Category()
    {
    }

    public Category(CreateCategoryParameters parameters)
    {
        SetTitle(new SetCategoryTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public void SetTitle(SetCategoryTitleParameters parameters)
    {
        _title = parameters.Title;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetParent(SetCategoryParentParameters parameters)
    {
        _parent = parameters.Parent;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddChildren(AddCategoryChildrenParameters parameters)
    {
        _children.AddRange(parameters.Children
            .DistinctBy(static c => c.Title)
            .Select(c => new Category(new CreateCategoryParameters
            {
                Title = c.Title,
                TimeProvider = parameters.TimeProvider
            })));

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void RemoveChildren(RemoveCategoryChildrenParameters parameters)
    {
        foreach (var child in parameters.Children)
        {
            _children.Remove(child);
        }
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}