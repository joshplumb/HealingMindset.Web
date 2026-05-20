using HealingMindset.Repositories.Context;
using HealingMindset.Repositories.Models;
using HealingMindset.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealingMindset.Repositories.Repositories
{
    public class VideoResourceRepository : BaseRepository
    {
        private readonly VideoResourceDatabaseContext _context;
        public VideoResourceRepository(VideoResourceDatabaseContext context, IConfiguration configuration) : base(configuration)
        {
            _context = context;
        }
    }
}



