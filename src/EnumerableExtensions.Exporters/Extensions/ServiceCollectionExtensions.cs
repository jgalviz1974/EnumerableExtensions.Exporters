using EnumerableExtensions.Exporters.Abstractions;
using EnumerableExtensions.Exporters.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnumerableExtensions.Exporters.Extensions;

/// <summary>
/// Provides dependency injection registration methods for exporter services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="IExporterService"/> and its implementation.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddExporterService(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddSingleton<IExporterService, ExporterService>();
        return services;
    }
}
