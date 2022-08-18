using TestTask.Services.DataTransferObject;

namespace TestTask.Services.Interfaces;

public interface IActivityAreasService
{
    Task<IEnumerable<Organization>> GetActivityAreasAsync();
    void DeleteAsync(int id);
    void Put(Organization activityArea);
}