namespace HealingMindset.Api.Features.VideoResources;
public static class VideoEndpointMapping
{
    public static void MapVideoEndpoints(this IEndpointRouteBuilder app)
    {
        var videoGroup = app.MapGroup("/api/videos");

        CreateVideo.MapEndpoint(videoGroup);
        DeleteVideo.MapEndpoint(videoGroup);
        GetAllVideos.MapEndpoint(videoGroup);
        GetVideoById.MapEndpoint(videoGroup);
        UpdateVideo.MapEndpoint(videoGroup);
    }
}