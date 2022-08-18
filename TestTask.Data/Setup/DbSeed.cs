namespace TestTask.Data.Setup;

using TestTask.Data.Context;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeed
{
    private static void Add(MainDBContext context)
    {
    }

    public static void Execute(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var context = scope.ServiceProvider.GetRequiredService<MainDBContext>();
        Add(context);
    }
}
