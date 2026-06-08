using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Api.Features.VideoResources;
public static class GetAllVideos
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (IVideoResourceService videoService) =>
        {
            var videos = await videoService.GetAll();
            return TypedResults.Ok(videos);
        })
            .WithSummary("Get all videos");
    }
}
