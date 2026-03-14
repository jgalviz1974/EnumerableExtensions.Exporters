using EnumerableExtensions.Exporters.Abstractions;
using EnumerableExtensions.Exporters.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnumerableExtensions.Exporters.Extensions;

/// <summary>
/// Provides export extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExporterExtensions
{
    private static readonly IExporterService FallbackExporterService = new ExporterService();

    /// <summary>
    /// Exports the sequence to a JSON file.
    /// </summary>
    /// <typeparam name="T">The element type of the sequence.</typeparam>
    /// <param name="data">The data to export.</param>
    /// <param name="filePath">The destination file path.</param>
    /// <param name="serviceProvider">An optional service provider used to resolve <see cref="IExporterService"/>.</param>
    /// <returns>A task that completes when export finishes.</returns>
    public static Task ExportToJson<T>(this IEnumerable<T> data, string filePath, IServiceProvider? serviceProvider = null)
    {
        return ResolveExporter(serviceProvider).ExportToJsonAsync(data, filePath);
    }

    /// <summary>
    /// Exports the sequence to a compressed JSON file using GZip.
    /// </summary>
    /// <typeparam name="T">The element type of the sequence.</typeparam>
    /// <param name="data">The data to export.</param>
    /// <param name="filePath">The destination file path.</param>
    /// <param name="serviceProvider">An optional service provider used to resolve <see cref="IExporterService"/>.</param>
    /// <returns>A task that completes when export finishes.</returns>
    public static Task ExportToCompressedJson<T>(this IEnumerable<T> data, string filePath, IServiceProvider? serviceProvider = null)
    {
        return ResolveExporter(serviceProvider).ExportToCompressedJsonAsync(data, filePath);
    }

    /// <summary>
    /// Exports the sequence to a MessagePack file.
    /// </summary>
    /// <typeparam name="T">The element type of the sequence.</typeparam>
    /// <param name="data">The data to export.</param>
    /// <param name="filePath">The destination file path.</param>
    /// <param name="serviceProvider">An optional service provider used to resolve <see cref="IExporterService"/>.</param>
    /// <returns>A task that completes when export finishes.</returns>
    public static Task ExportToMessagePack<T>(this IEnumerable<T> data, string filePath, IServiceProvider? serviceProvider = null)
    {
        return ResolveExporter(serviceProvider).ExportToMessagePackAsync(data, filePath);
    }

    private static IExporterService ResolveExporter(IServiceProvider? serviceProvider)
    {
        return serviceProvider?.GetService<IExporterService>() ?? FallbackExporterService;
    }
}
