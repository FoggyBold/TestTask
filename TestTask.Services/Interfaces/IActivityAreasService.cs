using TestTask.Services.DataTransferObject;

namespace TestTask.Services.Interfaces;

public interface IActivityAreasService
{
    Task<IEnumerable<ActivityArea>> GetActivityAreasAsync();
    void DeleteAsync(int id);
    void Put(ActivityArea activityArea);
}