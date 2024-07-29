using BlazorWasmAuth.Api.Common.Api;
using BlazorWasmAuth.Api.Endpoints.Identity;
using BlazorWasmAuth.Api.Models;

namespace BlazorWasmAuth.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoint(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints
            .MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "Ok" });

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}