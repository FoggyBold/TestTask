namespace TestTask.Services.Services;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Context;
using TestTask.Services.DataTransferObject;
using TestTask.Services.Interfaces;

public class OrganizationService : IOrganizationsService
{
    private readonly MainDBContext context;

    public OrganizationService(MainDBContext context)
    {
        this.context = context;
    }

    public async void DeleteAsync(int id)
    {
        var organization = context
            .Organizations
            .FirstOrDefault(el => el.ID == id);

        if (organization != null)
        {
            context.Organizations.Remove(organization);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Organization>> GetOrganizationsAsync()
    {
        var organizatios = context
            .Organizations
            .AsQueryable();

        var data = (await organizatios.ToListAsync())
            .Select(organization => new Organization
            { 
                ID = organization.ID,
                FullName = organization.FullName,
                ShortName = organization.ShortName,
                DirectorsFullName = organization.DirectorsFullName,
                AuthorizedCapital = organization.AuthorizedCapital,
                INN = organization.INN,
                KPP = organization.KPP,
                OGRN = organization.OGRN,
                ActivityArea = new ActivityArea
                {
                    ID = organization.ActivityAreaId,
                    Name = organization.ActivityArea.Name
                }
            });

       return data;
    }

    public async void Put(Organization organization)
    {
        var newOrganization = new Data.Entities.Organization
        {
            FullName = organization.FullName,
            ShortName = organization.ShortName
        };

        await context.Organizations.AddAsync(newOrganization);
        await context.SaveChangesAsync();
    }
}
