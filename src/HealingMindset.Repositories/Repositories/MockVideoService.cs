using HealingMindset.Repositories.Models;
using HealingMindset.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace HealingMindset.Repositories.Services
{
    public class MockVideoService : IVideoResourceService
    {
        private static readonly List<VideoResourceModel> _videos = new List<VideoResourceModel>
        {
            new VideoResourceModel { VideoResourceId = 1, Title = "Healing Soundscapes", YoutubeId = "dQw4w9WgXcQ", Description = "Deep relaxation." },
            new VideoResourceModel { VideoResourceId = 2, Title = "Mindful Breathing", YoutubeId = "2OEL4P1Rz04", Description = "Focus on the breath." },
            new VideoResourceModel { VideoResourceId = 3, Title = "Ocean Waves", YoutubeId = "dQw4w9WgXcQ", Description = "Calming surf sounds." },
            new VideoResourceModel { VideoResourceId = 4, Title = "Forest Rain", YoutubeId = "2OEL4P1Rz04", Description = "Gentle rain shower." },
            new VideoResourceModel { VideoResourceId = 5, Title = "Morning Meditation", YoutubeId = "dQw4w9WgXcQ", Description = "Start your day centered." },
            new VideoResourceModel { VideoResourceId = 6, Title = "Sleep Hypnosis", YoutubeId = "2OEL4P1Rz04", Description = "Fall asleep fast." },
            new VideoResourceModel { VideoResourceId = 7, Title = "Anxiety Relief", YoutubeId = "dQw4w9WgXcQ", Description = "Calm your nervous system." },
            new VideoResourceModel { VideoResourceId = 8, Title = "White Noise", YoutubeId = "2OEL4P1Rz04", Description = "Steady static for focus." },
            new VideoResourceModel { VideoResourceId = 9, Title = "Tibetan Singing Bowls", YoutubeId = "dQw4w9WgXcQ", Description = "Chakra alignment frequencies." },
            new VideoResourceModel { VideoResourceId = 10, Title = "Zen Garden Ambience", YoutubeId = "2OEL4P1Rz04", Description = "Peaceful background atmosphere." }
        };

        public async Task<List<VideoResourceModel>> GetAll()
        {
            return await Task.FromResult(_videos);
        }

        public async Task<VideoResourceModel> GetByID(int videoResourceID)
        {
            // Actually pulls the correct video matching the ID passed from your URL
            var video = _videos.FirstOrDefault(v => v.VideoResourceId == videoResourceID);
            return await Task.FromResult(video!);
        }

        public async Task<VideoResourceModel> Create(VideoResourceModel videoResource)
        {
            return await Task.FromResult(videoResource);
        }

        public async Task<VideoResourceModel> Update(VideoResourceModel videoResource)
        {
            return await Task.FromResult(videoResource);
        }

        public async Task<bool> Delete(int videoResourceID)
        {
            return await Task.FromResult(true);
        }
    }
}