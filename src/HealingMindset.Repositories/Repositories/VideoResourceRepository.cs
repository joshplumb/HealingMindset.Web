using HealingMindset.Repositories.Context;
using HealingMindset.Repositories.Models;
using HealingMindset.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HealingMindset.Repositories.Interfaces;

namespace HealingMindset.Repositories.Repositories
{
    public class VideoResourceRepository : BaseRepository, IVideoResourceService
    {
        private readonly VideoResourceDatabaseContext _context;
        public VideoResourceRepository(VideoResourceDatabaseContext context, IConfiguration configuration) : base(configuration)
        {
            _context = context;
        }

        public async Task<VideoResourceModel> Create(VideoResourceModel videoResource)
        {
            await _context.AddAsync(videoResource);
            
            await _context.SaveChangesAsync();

            return videoResource;
        }
        public async Task<List<VideoResourceModel>> GetAll()
        {
            var videoResources = await _context.VideoResources.ToListAsync();

            return videoResources;
        }
        public async Task<VideoResourceModel> GetByID(int videoResourceID)
        {
            var foundVideoResources = await _context.VideoResources.FindAsync(videoResourceID);

            return foundVideoResources;
        }

        public async Task<VideoResourceModel> Update(VideoResourceModel  videoResource)
        {
            _context.Update(videoResource);

            await _context.SaveChangesAsync();

            return videoResource;
        }
        public async Task<bool> Delete(int videoResourceID)
        {
            var foundVideoResource = await _context.VideoResources.FindAsync(videoResourceID);

            if(foundVideoResource == null) 
                throw new Exception("ID not found.");

            _context.VideoResources.Remove(foundVideoResource);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}



