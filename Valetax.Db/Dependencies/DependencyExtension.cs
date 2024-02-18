using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Valetax.Db.Context;
using Valetax.Db.Repositories;
using Valetax.Db.Repositories.Interfaces;

namespace Valetax.Db.Dependencies;

public static class DependencyExtension
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configs)
    {
        var assembly = typeof(DependencyExtension).Assembly.GetName().Name;

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configs.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(assembly ?? "Valetax.Db")));
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITreeRepository, TreeRepository>();
        services.AddScoped<IExceptionJournalRepository, ExceptionJournalRepository>();
    }
}