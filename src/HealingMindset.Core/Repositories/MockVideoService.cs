using HealingMindset.Repositories.Models;
using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Core.Services
{
    public class MockVideoService : IVideoResourceService
    {
        public async Task<IEnumerable<VideoResourceModel>> GetAllVideoResourcesAsync()
        {
            var videos = new List<VideoResourceModel>
            {
                new VideoResourceModel { Title = "Healing Soundscapes", youtubeId = "dQw4w9WgXcQ", Description = "Deep relaxation." },
                new VideoResourceModel { Title = "Mindful Breathing", youtubeId = "2OEL4P1Rz04", Description = "Focus on the breath." }
            };

            return await Task.FromResult(videos);
        }
    }
}
