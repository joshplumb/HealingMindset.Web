using HealingMindset.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealingMindset.Repositories.Interfaces;

public interface IVideoResourceService
{
    Task<IEnumerable<VideoResourceModel>> GetAllVideoResourcesAsync();
}