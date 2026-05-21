using HealingMindset.Repositories.Models;
using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Repositories.Services
{
    public class MockVideoService : IVideoResourceService
    {
        public async Task<List<VideoResourceModel>> GetAll()
        {
            var videos = new List<VideoResourceModel>
            {
                new VideoResourceModel { Title = "Healing Soundscapes", YoutubeId = "dQw4w9WgXcQ", Description = "Deep relaxation." },
                new VideoResourceModel { Title = "Mindful Breathing", YoutubeId = "2OEL4P1Rz04", Description = "Focus on the breath." }
            };

            return await Task.FromResult(videos);
        }
    }
}
