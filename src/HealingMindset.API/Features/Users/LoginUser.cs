using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.DataAccess.Context;
using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace HealingMindset.Api.Features.Users;

public record LoginUserRequest(string Email, string password);
public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.password).NotEmpty();
    }
}
public static class LoginUser
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users/login", HandleLoginUser)
            .WithSummary("Log in a user")
            .AllowAnonymous();
    }
    private static async Task<IResult> HandleLoginUser(
    LoginUserRequest request,
    UserManager<UserModel> userManager,
    SignInManager<UserModel> signInManager)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return Results.BadRequest(new { message = "Invalid email or password" });
        }

        var result = await signInManager.PasswordSignInAsync(user, request.password, isPersistent: true, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Results.Ok(new { message = "Login was successful" });
        }

        return Results.BadRequest(new { message = "Invalid email or password" });
    }
}
