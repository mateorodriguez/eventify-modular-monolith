using System.Reflection;
using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Domain.Categories;
using Eventify.Modules.Events.Domain.Events;
using Eventify.Modules.Events.Domain.TicketTypes;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Modules.Events.Infrastructure.Database;

internal sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) 
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }
    internal DbSet<Category> Categories { get; set; }
    internal DbSet<TicketType> TicketTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
        
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}