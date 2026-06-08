namespace HealingMindset.Api.Features.Users;
public static class UserEndpointMapping
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var userGroup = app.MapGroup("/");


    }
}
