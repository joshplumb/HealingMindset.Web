using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Api.Features.VideoResources;
public static class GetAllVideoFeature
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/videos", async (IVideoResourceService videoService) =>
        {
            var videos = await videoService.GetAll();
            return TypedResults.Ok(videos);
        });
    }
}
