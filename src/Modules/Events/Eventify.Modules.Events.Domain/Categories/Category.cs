using Eventify.Modules.Events.Domain.Abstractions;

namespace Eventify.Modules.Events.Domain.Categories;

public sealed class Category : Entity
{
    private Category()
    {
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public bool IsArchived { get; private set; }

    public static Category Create(string name)
    {
        Category category = new()
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        
        category.Raise(new CategoryCreatedDomainEvent(category.Id));
        
        return category;
    }

    public void Archive()
    {
        IsArchived = true;
        
        Raise(new CategoryArchiveDomainEvent(Id));
    }

    public void ChangeName(string name)
    {
        if (Name == name)
        {
            return;
        }
        
        Name = name;
        
        Raise(new CategoryNameChangedDomainEvent(Id, name));
    }
}