using Eventify.Modules.Events.Infrastructure;
using Eventify.Modules.Events.Infrastructure.Database;
using Eventify.Modules.Events.Presentation.Events;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEventsModule(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyEventsMigrations();
}

app.UseHttpsRedirection();

app.MapEventsEndpoints();

app.Run();