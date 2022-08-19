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

    public void Delete(int id)
    {
        var organization = context
            .Organizations
            .FirstOrDefault(el => el.ID == id);

        if (organization != null)
        {
            context.Organizations.Remove(organization);
            context.SaveChanges();
        }
    }

    public async Task<IEnumerable<Organization>> GetOrganizationsAsync()
    {
        var organizatios = context
            .Organizations
            .OrderBy(el => el.ActivityArea.Name)
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
                ActivityAreaId = organization.ActivityAreaId
            });

       return data;
    }

    public void Put(Organization organization)
    {
        var newOrganization = new Data.Entities.Organization
        {
            FullName = organization.FullName,
            ShortName = organization.ShortName,
            DirectorsFullName = organization.DirectorsFullName,
            AuthorizedCapital = organization.AuthorizedCapital,
            INN = organization.INN,
            KPP = organization.KPP,
            OGRN = organization.OGRN,
            ActivityAreaId = organization.ActivityAreaId
        };

        context.Organizations.Add(newOrganization);
        context.SaveChanges();
    }

    public async void Update(Organization organization)
    {
        var data = await context.Organizations.FirstOrDefaultAsync(el => el.ID == organization.ID);
        if(data != null)
        {
            data.OGRN = organization.OGRN;
            data.KPP = organization.KPP;
            data.INN = organization.INN;
            data.DirectorsFullName = organization.DirectorsFullName;
            data.ActivityAreaId = organization.ActivityAreaId;
            data.FullName = organization.FullName;
            data.ShortName = organization.ShortName;
            data.AuthorizedCapital = organization.AuthorizedCapital;

            context.SaveChanges();
        }
    }
}
