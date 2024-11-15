using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Events;

public static class EventEndpoints
{
    private static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CancelEvent.MapEndpoint(app);
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
        GetEvents.MapEndpoint(app);
        PublishEvent.MapEndpoint(app);
        RescheduleEvent.MapEndpoint(app);
        SearchEvents.MapEndpoint(app);
    }

    public static IEndpointRouteBuilder MapEventsEndpoints(this IEndpointRouteBuilder app)
    {
        MapEndpoints(app);
        
        return app;
    }
}