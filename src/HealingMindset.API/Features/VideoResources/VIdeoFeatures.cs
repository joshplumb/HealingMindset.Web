namespace HealingMindset.Api.Features.VideoResources;

public static class VideoFeatures
{
    public static void MapVideos(this IEndpointRouteBuilder app)
    {
        CreateVideoFeature.MapEndpoint(app);
        UpdateVideoFeature.MapEndpoint(app);
        GetAllVideoFeature.MapEndpoint(app);
    }
}