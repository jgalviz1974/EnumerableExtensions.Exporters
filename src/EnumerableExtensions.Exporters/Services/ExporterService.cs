using System.IO.Compression;
using System.Text.Json;
using EnunerableExtensions.Exporters.Abstractions;
using MessagePack;
using MessagePack.Resolvers;

namespace EnunerableExtensions.Exporters.Services;

/// <summary>
/// Provides export operations for enumerable data.
/// </summary>
public sealed class ExporterService : IExporterService
{
    private static readonly MessagePackSerializerOptions MessagePackOptions =
        MessagePackSerializerOptions.Standard.WithResolver(ContractlessStandardResolver.Instance);

    /// <inheritdoc />
    public async Task ExportToJsonAsync<T>(IEnumerable<T> data, string filePath)
    {
        ValidateArguments(data, filePath);
        EnsureDirectory(filePath);

        await using var stream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(stream, data);
    }

    /// <inheritdoc />
    public async Task ExportToCompressedJsonAsync<T>(IEnumerable<T> data, string filePath)
    {
        ValidateArguments(data, filePath);
        EnsureDirectory(filePath);

        await using var fileStream = File.Create(filePath);
        await using var gzipStream = new GZipStream(fileStream, CompressionLevel.Optimal);
        await JsonSerializer.SerializeAsync(gzipStream, data);
    }

    /// <inheritdoc />
    public async Task ExportToMessagePackAsync<T>(IEnumerable<T> data, string filePath)
    {
        ValidateArguments(data, filePath);
        EnsureDirectory(filePath);

        await using var stream = File.Create(filePath);
        await MessagePackSerializer.SerializeAsync(stream, data, MessagePackOptions);
    }

    private static void ValidateArguments<T>(IEnumerable<T> data, string filePath)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path cannot be null or whitespace.", nameof(filePath));
        }
    }

    private static void EnsureDirectory(string filePath)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (string.IsNullOrEmpty(directory))
        {
            return;
        }

        Directory.CreateDirectory(directory);
    }
}
