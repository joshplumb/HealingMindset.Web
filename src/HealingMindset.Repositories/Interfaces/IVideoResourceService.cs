using HealingMindset.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealingMindset.Repositories.Interfaces;

public interface IVideoResourceService
{
    Task<VideoResourceModel> Create(VideoResourceModel videoResourceModel);
    Task<List<VideoResourceModel>> GetAll();
    Task<VideoResourceModel> GetByID(int videoResourceID);
    Task<VideoResourceModel> Update(VideoResourceModel videoResourceModel);
    Task<bool> Delete(int videoResourceID);
}