namespace TestTask.WEB.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestTask.Services.DataTransferObject;
using TestTask.Services.Interfaces;
using TestTask.WEB.ViewModels;

public class OrganizationsController : Controller
{
    private readonly IOrganizationsService organizationsService;
    private readonly IActivityAreasService activityAreasService;
    public OrganizationsController(IOrganizationsService organizationsService, IActivityAreasService activityAreasService)
    {
        this.organizationsService = organizationsService;
        this.activityAreasService = activityAreasService;
    }

    public IActionResult Index()
    {
        var organizations = organizationsService.GetOrganizationsAsync().Result;
        var organizationsObj = new OrganizationsViewModel
        {
            Organizations = organizations
        };
        return View(organizationsObj);
    }

    [HttpGet]
    public IActionResult AddOrganization()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddOrganization(OrganizationModel model)
    {
        if (ModelState.IsValid)
        {
            var activityArea = activityAreasService.GetActivityAreaAsync(model.ActivityArea).Result;
            if (activityArea != null)
            {
                var organization = new Organization
                {
                    FullName = model.FullName,
                    ShortName = model.ShortName,
                    DirectorsFullName = model.DirectorsFullName,
                    ActivityAreaId = activityArea.ID,
                    AuthorizedCapital = model.AuthorizedCapital,
                    INN = model.INN,
                    KPP = model.KPP,
                    OGRN = model.OGRN
                };
                organizationsService.Put(organization);
                return RedirectToAction("Index", "Organizations");
            }
            ModelState.AddModelError("", $"Сфера деятельности {model.ActivityArea} отсутствует в базе");
        }
        return View(model);
    }

    public IActionResult DellOrganization(int id)
    {
        organizationsService.Delete(id);
        return RedirectToAction("Index", "Organizations");
    }
}