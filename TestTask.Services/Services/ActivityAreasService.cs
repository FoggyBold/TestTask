namespace TestTask.Services.Services;

using Microsoft.EntityFrameworkCore;
using System;
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

    public async void DeleteAsync(int id)
    {
        var activityArea = context
            .ActivityAreas
            .FirstOrDefault(el => el.ID == id);

        if (activityArea != null)
        {
            context.ActivityAreas.Remove(activityArea);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ActivityArea>> GetActivityAreasAsync()
    {
        var activiteAreas = context
            .ActivityAreas
            .AsQueryable();

        var data = (await activiteAreas.ToListAsync())
            .Select(activiteArea => new ActivityArea
            {
                ID = activiteArea.ID,
                Name = activiteArea.Name
            });

        return data;
    }

    public async void Put(ActivityArea activityArea)
    {
        var newActiviteArea = new Data.Entities.ActivityArea
        {
            Name = activityArea.Name
        };

        await context.ActivityAreas.AddAsync(newActiviteArea);
        await context.SaveChangesAsync();
    }
}