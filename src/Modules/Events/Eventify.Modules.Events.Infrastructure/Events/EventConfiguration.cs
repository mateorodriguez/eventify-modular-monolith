using Eventify.Modules.Events.Domain.Categories;
using Eventify.Modules.Events.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventify.Modules.Events.Infrastructure.Events;

public sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasOne<Category>().WithMany();
    }
}