using FluentValidation;
using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;

namespace HealingMindset.Api.Features.VideoResources

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

public static class CreateVideoFeature
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/videos", async (CreateVideoRequest request, IVideoResourceService videoService) =>
        {
            var databaseModel = new VideoResourceModel
            {
                Title = request.Title,
                YoutubeId = request.YoutubeId,
                Description = request.Description
            };

            await videoService.Create(databaseModel);
            return TypedResults.Created($"/api/videos", databaseModel);
        });
    }
}