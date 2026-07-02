using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.DataAccess.Context;
using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace HealingMindset.Api.Features.Users;

public class LogoutUser
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users/logout", HandleLogoutUser)
            .WithSummary("Logout current user");
    }
    private static async Task<IResult> HandleLogoutUser(
        SignInManager<UserModel> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok(new { message = "Logged out" });
    }
}
