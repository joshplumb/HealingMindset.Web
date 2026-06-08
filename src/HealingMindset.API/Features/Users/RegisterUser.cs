using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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

    public static async Task<Results<Created<UserModel>, BadRequest> HandleRegisterUser(RegisterUserRequest request, )
    {

    }
}