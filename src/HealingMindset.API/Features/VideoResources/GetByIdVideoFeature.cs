using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Api.Features.VideoResources;
public static class GetByIdVideoFeature
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/{videoResourceId:int}", async (int videoResourceId, IVideoResourceService videoService) =>
        {
            var video = await videoService.GetByID(videoResourceId);
            if (video == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(video);
        });
    }
}
