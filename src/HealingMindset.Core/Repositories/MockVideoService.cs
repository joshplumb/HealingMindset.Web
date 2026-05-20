using HealingMindset.Core.Entities;
using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Core.Services
{
    public class MockVideoService : IVideoResourceService
    {
        public async Task<IEnumerable<VideoResource>> GetAllVideoResourcesAsync()
        {
            var videos = new List<VideoResource>
            {
                new VideoResource { Title = "Healing Soundscapes", youtubeId = "dQw4w9WgXcQ", Description = "Deep relaxation." },
                new VideoResource { Title = "Mindful Breathing", youtubeId = "2OEL4P1Rz04", Description = "Focus on the breath." }
            };

            return await Task.FromResult(videos);
        }
    }
}
