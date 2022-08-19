using TestTask.Services.DataTransferObject;

namespace TestTask.Services.Interfaces;

public interface IOrganizationsService
{
    Task<IEnumerable<Organization>> GetOrganizationsAsync();
    void Delete(int id);
    void Put(Organization organization);
}
