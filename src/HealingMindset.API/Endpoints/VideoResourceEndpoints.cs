using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;

namespace HealingMindset.Api.Endpoints
{
    public static class VideoResourceEndpoints
    {
        public static void MapVideoEndpoints(this IEndpointRouteBuilder app)
        {
            var videoResourceGroup = app.MapGroup("/api/videos");

            videoResourceGroup.MapPost("/", CreateVideo);
            videoResourceGroup.MapGet("/", GetAllVideos);
            videoResourceGroup.MapGet("/{videoResourceId:int}", GetVideoByID);
            videoResourceGroup.MapPut("/", UpdateVideo);
            videoResourceGroup.MapDelete("/{videoResourceId:int}", DeleteVideo);
        }
        public static async Task<IResult> CreateVideo(VideoResourceModel videoResource,IVideoResourceService videoService)
        {
            await videoService.Create(videoResource);
            return TypedResults.Created($"/api/videos", videoResource);
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
        public static async Task<IResult> UpdateVideo(VideoResourceModel videoResource, IVideoResourceService videoService)
        {
            var video = await videoService.Update(videoResource);
            return TypedResults.NoContent();
        }
        public static async Task<IResult> DeleteVideo(int videoResourceId, IVideoResourceService videoService)
        {
            await videoService.Delete(videoResourceId);
            return TypedResults.NoContent();
        }
    }
}
