using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.DataAccess.Context;
using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace HealingMindset.Api.Features.Users;

public record LoginUserRequest(string Username, string password);
public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.password).NotEmpty();
    }
}
public static class LoginUser
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost()
    }
}
