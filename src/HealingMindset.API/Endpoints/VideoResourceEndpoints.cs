using HealingMindset.Repositories.Interfaces;
using HealingMindset.Repositories.Models;
using HealingMindset.Api.DTOs;

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
            videoResourceGroup.MapPut("/{videoResourceId:int}", UpdateVideo);
            videoResourceGroup.MapDelete("/{videoResourceId:int}", DeleteVideo);
        }
        public static async Task<IResult> CreateVideo(VideoRequestDTO videoRequest, IVideoResourceService videoService)
        {
            var databaseModel = new VideoResourceModel
            {
                Title = videoRequest.Title,
                YoutubeId = videoRequest.YoutubeId,
                Description = videoRequest.Description
            };

            await videoService.Create(databaseModel);
            return TypedResults.Created($"/api/videos", databaseModel);
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
        public static async Task<IResult> UpdateVideo(int videoId, VideoRequestDTO videoRequest, IVideoResourceService videoService)
        {
            var databaseModel = new VideoResourceModel
            {
                VideoResourceId = videoId,
                Title = videoRequest.Title,
                YoutubeId = videoRequest.YoutubeId,
                Description = videoRequest.Description
            };

            var video = await videoService.Update(databaseModel);
            return TypedResults.NoContent();
        }
        public static async Task<IResult> DeleteVideo(int videoResourceId, IVideoResourceService videoService)
        {
            await videoService.Delete(videoResourceId);
            return TypedResults.NoContent();
        }
    }
}
