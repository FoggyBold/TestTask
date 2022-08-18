namespace TestTask.Data.Context;

using TestTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class MainDBContext : DbContext
{
    public DbSet<ActivityArea> ActivityAreas { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public MainDBContext(DbContextOptions<MainDBContext> options)
        : base(options)
    {
    }
}