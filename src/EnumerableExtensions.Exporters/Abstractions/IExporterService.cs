namespace EnunerableExtensions.Exporters.Abstractions;

/// <summary>
/// Defines asynchronous export operations for enumerable data.
/// </summary>
public interface IExporterService
{
    /// <summary>
    /// Exports data to a JSON file.
    /// </summary>
    /// <typeparam name="T">The element type of the sequence.</typeparam>
    /// <param name="data">The data to export.</param>
    /// <param name="filePath">The destination file path.</param>
    /// <returns>A task that completes when export finishes.</returns>
    Task ExportToJsonAsync<T>(IEnumerable<T> data, string filePath);

    /// <summary>
    /// Exports data to a compressed JSON file using GZip.
    /// </summary>
    /// <typeparam name="T">The element type of the sequence.</typeparam>
    /// <param name="data">The data to export.</param>
    /// <param name="filePath">The destination file path.</param>
    /// <returns>A task that completes when export finishes.</returns>
    Task ExportToCompressedJsonAsync<T>(IEnumerable<T> data, string filePath);

    /// <summary>
    /// Exports data to a MessagePack file.
    /// </summary>
    /// <typeparam name="T">The element type of the sequence.</typeparam>
    /// <param name="data">The data to export.</param>
    /// <param name="filePath">The destination file path.</param>
    /// <returns>A task that completes when export finishes.</returns>
    Task ExportToMessagePackAsync<T>(IEnumerable<T> data, string filePath);
}
