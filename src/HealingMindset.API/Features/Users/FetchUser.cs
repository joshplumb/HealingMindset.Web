using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HealingMindset.Api.Features.Users;

public record FetchUserResponse(string Id, string Email, string UserName);

public static class FetchUser
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users/current", HandleFetchUser)
            .WithSummary("Fetch a User")
            .RequireAuthorization();
    }
    private static async Task<IResult> HandleFetchUser(
    ClaimsPrincipal userPrincipal,
    UserManager<UserModel> userManager)
    {
        var userId = userManager.GetUserId(userPrincipal);
        if (String.IsNullOrEmpty(userId))
        {
            return Results.Unauthorized();
        }
        var user = await userManager.FindByIdAsync(userId);
        if(user == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(new
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName
        });
    }
}