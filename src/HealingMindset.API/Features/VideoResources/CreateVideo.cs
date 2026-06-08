using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HealingMindset.Api.Features.VideoResources;
public record CreateVideoRequest(string Title, string YoutubeId, string Description);
public class CreateVideoValidator : AbstractValidator<CreateVideoRequest>
{
    public CreateVideoValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.YoutubeId).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
public static class CreateVideo
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleCreateVideoResource)
           .WithSummary("Create new video")
           .WithRequestValidation<CreateVideoRequest>()
           .RequireAuthorization();
    }
    public static async Task<Results<Created<VideoResourceModel>, BadRequest>> HandleCreateVideoResource(CreateVideoRequest request, IVideoResourceService videoService)
    {
        var databaseModel = new VideoResourceModel
        {
            Title = request.Title,
            YoutubeId = request.YoutubeId,
            Description = request.Description
        };

        await videoService.Create(databaseModel);
        return TypedResults.Created($"/api/videos", databaseModel);
    }
}
