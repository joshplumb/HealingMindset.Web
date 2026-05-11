using HealingMindset.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealingMindset.Core.Interfaces;

public interface IVideoService
{
    Task<IEnumerable<Video>> GetAllVideosAsync();
}