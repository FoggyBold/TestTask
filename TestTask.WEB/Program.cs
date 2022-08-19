using TestTask.Data.Context;
using TestTask.Data.Setup;
using Microsoft.EntityFrameworkCore;
using TestTask.Services.Interfaces;
using TestTask.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MainDbContext");

builder.Services.AddDbContext<MainDBContext>(option =>
{
    option.UseSqlServer(connectionString);
});

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddControllers();

builder.Services.AddTransient<IOrganizationsService, OrganizationService>();
builder.Services.AddTransient<IActivityAreasService, ActivityAreasService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}"
    );
});

DbInit.Execute(app.Services);

DbSeed.Execute(app.Services);

app.Run();
