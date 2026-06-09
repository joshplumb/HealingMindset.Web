using Microsoft.Extensions.Configuration;

namespace HealingMindset.DataAccess.Shared
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;
        protected readonly string _dbconnectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbconnectionString = GetConnectionString();
        }

        public string? GetConnectionString()
        {
            return _configuration.GetConnectionString("LocalConnection");
        }
    }
}
