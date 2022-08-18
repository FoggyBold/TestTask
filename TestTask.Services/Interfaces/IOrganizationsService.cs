using TestTask.Services.DataTransferObject;

namespace TestTask.Services.Interfaces;

public interface IOrganizationsService
{
    Task<IEnumerable<Organization>> GetOrganizationsAsync();
    void DeleteAsync(int id);
    void Put(Organization organization);
}
