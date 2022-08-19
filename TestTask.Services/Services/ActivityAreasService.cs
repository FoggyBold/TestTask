namespace TestTask.Services.Services;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Context;
using TestTask.Services.DataTransferObject;
using TestTask.Services.Interfaces;

public class ActivityAreasService : IActivityAreasService
{
    private readonly MainDBContext context;

    public ActivityAreasService(MainDBContext context)
    {
        this.context = context;
    }

    public void Delete(int id)
    {
        var activityArea = context
            .ActivityAreas
            .FirstOrDefault(el => el.ID == id);

        if (activityArea != null)
        {
            context.ActivityAreas.Remove(activityArea);
            context.SaveChanges();
        }
    }

    public async Task<ActivityArea> GetActivityAreaAsync(string name)
    {
        var activityArea = await context.ActivityAreas.FirstOrDefaultAsync(el => el.Name == name);
        if (activityArea != null)
        {
            return new ActivityArea
            {
                Name = activityArea.Name,
                ID = activityArea.ID
            };
        }
        return null;
    }

    public async Task<ActivityArea> GetActivityAreaAsync(int id)
    {
        var activityArea = await context.ActivityAreas.FirstOrDefaultAsync(el => el.ID == id);
        if (activityArea != null)
        {
            return new ActivityArea
            {
                Name = activityArea.Name,
                ID = activityArea.ID
            };
        }
        return null;
    }

    public async Task<IEnumerable<ActivityArea>> GetActivityAreasAsync()
    {
        var activityAreas = context
            .ActivityAreas
            .AsQueryable();

        var data = (await activityAreas.ToListAsync())
            .Select(activityArea => new ActivityArea
            {
                ID = activityArea.ID,
                Name = activityArea.Name
            });

        return data;
    }

    public void Put(ActivityArea activityArea)
    {
        var newActivityArea = new Data.Entities.ActivityArea
        {
            Name = activityArea.Name
        };

        context.ActivityAreas.Add(newActivityArea);
        context.SaveChanges();
    }
}