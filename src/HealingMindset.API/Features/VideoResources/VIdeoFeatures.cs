namespace HealingMindset.Api.Features.VideoResources;

public static class VideoFeatures
{
    public static void MapVideoEndpoints(this IEndpointRouteBuilder app)
    {
        var videoGroup = app.MapGroup("/api/videos");

        CreateVideoFeature.MapEndpoint(videoGroup);
        DeleteVideoFeature.MapEndpoint(videoGroup);
        GetAllVideoFeature.MapEndpoint(videoGroup);
        GetByIdVideoFeature.MapEndpoint(videoGroup);
        UpdateVideoFeature.MapEndpoint(videoGroup);
    }
}