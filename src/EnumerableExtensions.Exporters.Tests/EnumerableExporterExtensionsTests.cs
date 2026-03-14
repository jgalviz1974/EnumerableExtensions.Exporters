using System.IO.Compression;
using System.Text.Json;
using EnumerableExtensions.Exporters.Extensions;
using MessagePack;
using MessagePack.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace EnumerableExtensions.Exporters.Tests;

public class EnumerableExporterExtensionsTests
{
    private static readonly MessagePackSerializerOptions MessagePackOptions =
        MessagePackSerializerOptions.Standard.WithResolver(ContractlessStandardResolver.Instance);

    [Fact]
    public async Task ExportToJson_CreatesFile_AndRoundTripsData()
    {
        var filePath = GetTempFilePath(".json");
        var data = CreateSampleData();

        try
        {
            await data.ExportToJson(filePath);

            Assert.True(File.Exists(filePath));

            await using var stream = File.OpenRead(filePath);
            var result = await JsonSerializer.DeserializeAsync<List<SampleItem>>(stream);

            Assert.NotNull(result);
            Assert.Equal(data, result);
        }
        finally
        {
            DeleteIfExists(filePath);
        }
    }

    [Fact]
    public async Task ExportToCompressedJson_CreatesFile_AndRoundTripsData()
    {
        var filePath = GetTempFilePath(".json.gz");
        var data = CreateSampleData();

        try
        {
            await data.ExportToCompressedJson(filePath);

            Assert.True(File.Exists(filePath));

            await using var fileStream = File.OpenRead(filePath);
            await using var gzipStream = new GZipStream(fileStream, CompressionMode.Decompress);
            var result = await JsonSerializer.DeserializeAsync<List<SampleItem>>(gzipStream);

            Assert.NotNull(result);
            Assert.Equal(data, result);
        }
        finally
        {
            DeleteIfExists(filePath);
        }
    }

    [Fact]
    public async Task ExportToMessagePack_CreatesFile_AndRoundTripsData()
    {
        var filePath = GetTempFilePath(".mpack");
        var data = CreateSampleData();

        try
        {
            await data.ExportToMessagePack(filePath);

            Assert.True(File.Exists(filePath));

            await using var stream = File.OpenRead(filePath);
            var result = await MessagePackSerializer.DeserializeAsync<List<SampleItem>>(stream, MessagePackOptions);

            Assert.NotNull(result);
            Assert.Equal(data, result);
        }
        finally
        {
            DeleteIfExists(filePath);
        }
    }

    [Fact]
    public async Task ExportToJson_UsesExporterService_FromDependencyInjection()
    {
        var filePath = GetTempFilePath(".json");
        var data = CreateSampleData();
        var services = new ServiceCollection().AddExporterService();

        try
        {
            using var serviceProvider = services.BuildServiceProvider();
            await data.ExportToJson(filePath, serviceProvider);

            Assert.True(File.Exists(filePath));

            await using var stream = File.OpenRead(filePath);
            var result = await JsonSerializer.DeserializeAsync<List<SampleItem>>(stream);

            Assert.NotNull(result);
            Assert.Equal(data, result);
        }
        finally
        {
            DeleteIfExists(filePath);
        }
    }

    private static List<SampleItem> CreateSampleData() =>
    [
        new SampleItem(1, "First"),
        new SampleItem(2, "Second"),
        new SampleItem(3, "Third")
    ];

    private static string GetTempFilePath(string extension) =>
        Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}{extension}");

    private static void DeleteIfExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public sealed record SampleItem(int Id, string Name);
}
