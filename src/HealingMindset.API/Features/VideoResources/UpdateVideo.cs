using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;

namespace HealingMindset.Api.Features.VideoResources;
public record UpdateVideoRequest(string Title, string YoutubeId, string Description);
public class UpdateVideoValidator : AbstractValidator<UpdateVideoRequest>
{
    public UpdateVideoValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.YoutubeId).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
public static class UpdateVideo
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id:int}", async (int id, UpdateVideoRequest request, IVideoResourceService videoService) =>
        {
            var databaseModel = new VideoResourceModel
            {
                VideoResourceId = id,
                Title = request.Title,
                YoutubeId = request.YoutubeId,
                Description = request.Description
            };
            await videoService.Update(databaseModel);
            return TypedResults.NoContent();
        })
            .WithSummary("Update a video")
            .WithRequestValidation<UpdateVideoRequest>()
            .RequireAuthorization();
    }
}
