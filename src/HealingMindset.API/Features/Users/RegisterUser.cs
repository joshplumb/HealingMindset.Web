using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.DataAccess.Context;
using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace HealingMindset.Api.Features.Users;
public record RegisterUserRequest(string Username, string Email, string Password);
public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
public static class RegisterUser
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleRegisterUser)
            .WithSummary("Register and create a new user profile")
            .WithRequestValidation<RegisterUserRequest>();
    }

    public static async Task<Results<Created<UserModel>, BadRequest> HandleRegisterUser(RegisterUserRequest request, UserDatabaseContext context)
    {
        var databaseModel = new UserModel
        {
            UserName = request.Username,
            Email = request.Email,
        };
        var result = await 
    }
}