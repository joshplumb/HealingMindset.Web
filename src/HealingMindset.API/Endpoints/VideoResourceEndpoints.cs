using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;

namespace HealingMindset.Api.Endpoints
{
    public static class VideoResourceEndpoints
    {
        public static void MapVideoEndpoints(this IEndpointRouteBuilder app)
        {
            var videoResourceGroup = app.MapGroup("/api/videos");

            videoResourceGroup.MapDelete("/{videoResourceId:int}", DeleteVideo);
        }
        public static async Task<IResult> DeleteVideo(int videoResourceId, IVideoResourceService videoService)
        {
            await videoService.Delete(videoResourceId);
            return TypedResults.NoContent();
        }
    }
}
