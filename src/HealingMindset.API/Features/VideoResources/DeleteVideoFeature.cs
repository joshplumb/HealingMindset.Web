using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Api.Features.VideoResources;

public static class DeleteVideoFeature
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{videoResourceId:int}", async (int videoResourceId, IVideoResourceService videoService) =>
        {
            await videoService.Delete(videoResourceId);
            return TypedResults.NoContent();
        });
    }
}
