using Microsoft.Extensions.DependencyInjection;
using Valetax.Services.Interfaces;
using Valetax.Services.Services;

namespace Valetax.Services.Dependencies;

public static class DependencyExtension
{
    public static void RegisterServices(this IServiceCollection service)
    {
        service.AddScoped<ITreeService, TreeService>();
        service.AddScoped<IExceptionJournalService, ExceptionJournalService>();
    }
}