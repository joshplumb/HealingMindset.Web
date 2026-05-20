using HealingMindset.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealingMindset.Repositories.Interfaces;

public interface IVideoResourceService
{
    Task<IEnumerable<VideoResource>> GetAllVideoResourcesAsync();
}