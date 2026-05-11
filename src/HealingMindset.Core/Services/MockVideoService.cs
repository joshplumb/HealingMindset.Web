using HealingMindset.Core.Entities;
using HealingMindset.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealingMindset.Core.Services;

public class MockVideoService : IVideoService
{
    public async Task<IEnumerable<Video>> GetAllVideosAsync()
    {
        var videos = new List<Video>
        {
            new Video { Title = "Healing Soundscapes", youtubeId = "dQw4w9WgXcQ", Description = "Deep relaxation." },
            new Video { Title = "Mindful Breathing", youtubeId = "2OEL4P1Rz04", Description = "Focus on the breath." }
        };

        return await Task.FromResult(videos);
    }
}