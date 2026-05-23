namespace HealingMindset.Repositories.Models;

public class VideoResourceModel
{
    public int VideoResourceId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string YoutubeId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}