using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;

namespace HealingMindset.Api.Endpoints
{
    public static class VideoResourceEndpoints
    {
        public static void MapVideoEndpoints(this IEndpointRouteBuilder app)
        {
            var videoResourceGroup = app.MapGroup("/api/videos");

            videoResourceGroup.MapGet("/", GetAllVideos);
            videoResourceGroup.MapGet("/{videoResourceId:int}", GetVideoByID);
            videoResourceGroup.MapDelete("/{videoResourceId:int}", DeleteVideo);
        }
        
        public static async Task<IResult> GetAllVideos(IVideoResourceService videoService)
        {
            var videos = await videoService.GetAll();
            return TypedResults.Ok(videos);
        }
        public static async Task<IResult> GetVideoByID(int videoResourceId, IVideoResourceService videoService)
        {
            var video = await videoService.GetByID(videoResourceId);
            return video is null ? TypedResults.NotFound() : TypedResults.Ok(video);
        }
        public static async Task<IResult> DeleteVideo(int videoResourceId, IVideoResourceService videoService)
        {
            await videoService.Delete(videoResourceId);
            return TypedResults.NoContent();
        }
    }
}
