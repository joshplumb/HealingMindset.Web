using FluentValidation;
using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;

namespace HealingMindset.Api.Features.VideoResources
{
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
    public static class UpdateVideoFeature
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/{videoResourceId:int}", async (int id, UpdateVideoRequest request, IVideoResourceService videoService) =>
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
            });
        }
    }
}
