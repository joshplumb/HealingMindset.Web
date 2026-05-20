namespace HealingMindset.Repositories.Models;

public class VideoResourceModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string youtubeId { get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;
}