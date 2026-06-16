using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.DataAccess.Context;
using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace HealingMindset.Api.Features.Users;
public record RegisterUserRequest(string Username, string Email, string Password);
public record RegisterUserResponse(string Username, string Email);
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

    public static async Task<Results<Created<RegisterUserResponse>, BadRequest<IEnumerable<IdentityError>>>> HandleRegisterUser(RegisterUserRequest request, UserManager<UserModel> userManager)
    {
        var databaseModel = new UserModel
        {
            UserName = request.Username,
            Email = request.Email,
        };

        var result = await userManager.CreateAsync(databaseModel, request.Password);

        if(!result.Succeeded)
        {
            return TypedResults.BadRequest(result.Errors);
        }

        var response = new RegisterUserResponse(databaseModel.UserName, databaseModel.Email);

        return TypedResults.Created($"/api/users/{databaseModel.Id}", response);
    }
}