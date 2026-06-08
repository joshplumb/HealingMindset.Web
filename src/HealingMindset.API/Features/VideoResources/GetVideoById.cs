using HealingMindset.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HealingMindset.Api.Features.VideoResources;

public record GetByIdResponse(string Title, string YoutubeId, string Description);
public static class GetVideoById
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id:int}", HandleGetByIdAsync)
            .WithSummary("Get a single video");
    }
    public static async Task<Results<Ok<GetByIdResponse>, NotFound>> HandleGetByIdAsync(int id, IVideoResourceService videoService)
    {
        var video = await videoService.GetByID(id);
        if (video == null)
        {
            return TypedResults.NotFound();
        }
        var response = new GetByIdResponse(video.Title, video.YoutubeId, video.Description);
        return TypedResults.Ok(response);
    }
}
