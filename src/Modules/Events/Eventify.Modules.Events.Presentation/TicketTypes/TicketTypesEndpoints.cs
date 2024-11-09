using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.TicketTypes;

public static class TicketTypesEndpoints
{
    public static IEndpointRouteBuilder MapTicketTypesEndpoints(this IEndpointRouteBuilder app)
    {
        CreateTicketType.MapEndpoint(app);
        GetTicketType.MapEndpoint(app);
        GetTicketTypes.MapEndpoint(app);
        ChangeTicketTypePrice.MapEndpoint(app);
        
        return app;
    }
}