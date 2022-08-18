namespace TestTask.Services.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Context;
using TestTask.Services.DataTransferObject;
using TestTask.Services.Interfaces;

public class OrganizationService : IOrganizationsService
{
    private readonly MainDBContext context;
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ActivityArea>> GetActivityAreasAsync()
    {
        throw new NotImplementedException();
    }

    public void Put(ActivityArea activityArea)
    {
        throw new NotImplementedException();
    }
}
