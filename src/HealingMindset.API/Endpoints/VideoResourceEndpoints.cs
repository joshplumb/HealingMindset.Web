using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;

namespace HealingMindset.Api.Endpoints
{
    public static class VideoResourceEndpoints
    {
        public static void MapVideoEndpoints(this IEndpointRouteBuilder app)
        {
            var videoResourceGroup = app.MapGroup("/api/videos");

            videoResourceGroup.MapPost("/", async (VideoResourceModel videoResource, IVideoResourceService videoService) =>
                await videoService.Create(videoResource));
            videoResourceGroup.MapGet("/", async (IVideoResourceService videoService) =>
                await videoService.GetAll());
            videoResourceGroup.MapGet("/{videoResourceId:int}", async(int videoResourceId, IVideoResourceService videoService) =>
                await videoService.GetByID(videoResourceId));
            videoResourceGroup.MapPut("/", async(VideoResourceModel videoResource, IVideoResourceService videoService) =>
                await videoService.Update(videoResource));
            videoResourceGroup.MapDelete("/{videoResourceId:int}", async (int videoResourceId, IVideoResourceService videoService) =>
                await videoService.Delete(videoResourceId));
        }
    }
}
