using TestTask.Services.DataTransferObject;

namespace TestTask.Services.Interfaces;

public interface IActivityAreasService
{
    Task<IEnumerable<ActivityArea>> GetActivityAreasAsync();
    Task<ActivityArea> GetActivityAreaAsync(string name);
    Task<ActivityArea> GetActivityAreaAsync(int id);
    void Delete(int id);
    void Put(ActivityArea activityArea);
}