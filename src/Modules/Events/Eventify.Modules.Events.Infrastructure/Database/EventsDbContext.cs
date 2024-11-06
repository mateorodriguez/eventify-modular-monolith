using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Modules.Events.Infrastructure.Database;

internal sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) 
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}