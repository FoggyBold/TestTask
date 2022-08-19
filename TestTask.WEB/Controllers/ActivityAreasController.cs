namespace TestTask.WEB.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestTask.Services.DataTransferObject;
using TestTask.Services.Interfaces;
using TestTask.WEB.ViewModels;

public class ActivityAreasController : Controller
{
    private readonly IActivityAreasService activityAreasService;
    public ActivityAreasController(IActivityAreasService activityAreasService)
    {
        this.activityAreasService = activityAreasService;
    }

    public IActionResult Index()
    {
        var activityAreas = activityAreasService.GetActivityAreasAsync().Result;
        var activityAreasObj = new ActivityAreasViewModel
        {
            ActivityAreas = activityAreas
        };
        return View(activityAreasObj);
    }

    [HttpGet]
    public IActionResult AddActivityArea()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddActivityArea(ActivityAreaModel model)
    {
        if (ModelState.IsValid)
        {
            var activityArea = new ActivityArea
            {
                Name = model.Name
            };
            activityAreasService.Put(activityArea);
            return RedirectToAction("Index", "ActivityAreas");
        }
        return View(model);
    }

    public IActionResult DellActivityArea(int id)
    {
        activityAreasService.Delete(id);
        return RedirectToAction("Index", "ActivityAreas");
    }
}