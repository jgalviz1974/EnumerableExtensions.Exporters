# EnumerableExtensions.Exporters

Language / Idioma: [English](#english) | [Español](#espanol)

A small .NET library that adds extension methods to `IEnumerable<T>` so collections can be exported to:

- JSON
- Compressed JSON with GZip
- MessagePack

It also supports dependency injection through `IExporterService`.

> Note: the current public namespace exposed by the library is `EnunerableExtensions.Exporters`.

---

<a id="english"></a>
# English

[Go to Español](#espanol)

## Overview

`EnumerableExtensions.Exporters` provides async extension methods for exporting any `IEnumerable<T>` to disk in multiple formats.

Available extension methods:

- `ExportToJson`
- `ExportToCompressedJson`
- `ExportToMessagePack`

You can use them directly or resolve the exporter through dependency injection.

## Installation

Add the package reference to your project:

```xml
<PackageReference Include="EnumerableExtensions.Exporters" Version="x.y.z" />
```

Or reference the project directly during local development.

## Namespace

```csharp
using EnunerableExtensions.Exporters.Extensions;
```

## Basic usage

```csharp
using EnunerableExtensions.Exporters.Extensions;

var people = new[]
{
    new Person(1, "Ada"),
    new Person(2, "Grace"),
    new Person(3, "Linus")
};

await people.ExportToJson("exports/people.json");
await people.ExportToCompressedJson("exports/people.json.gz");
await people.ExportToMessagePack("exports/people.mpack");

public sealed record Person(int Id, string Name);
```

## Usage with dependency injection

If you already use `Microsoft.Extensions.DependencyInjection`, register the service like this:

```csharp
using EnunerableExtensions.Exporters.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddExporterService();

using var serviceProvider = services.BuildServiceProvider();

var people = new[]
{
    new Person(1, "Ada"),
    new Person(2, "Grace")
};

await people.ExportToJson("exports/people.json", serviceProvider);

public sealed record Person(int Id, string Name);
```

## Output formats

### JSON
Creates a plain JSON file.

```csharp
await people.ExportToJson("exports/people.json");
```

### Compressed JSON
Creates a GZip-compressed JSON file.

```csharp
await people.ExportToCompressedJson("exports/people.json.gz");
```

### MessagePack
Creates a compact binary file using MessagePack.

```csharp
await people.ExportToMessagePack("exports/people.mpack");
```

## Behavior notes

- All export operations are asynchronous.
- Target directories are created automatically when needed.
- `filePath` cannot be null, empty, or whitespace.
- `data` cannot be null.
- If no `IServiceProvider` is provided, the library uses its internal exporter service.

## Typical scenario

This library is useful when you need to:

- save query results to disk
- archive collections in compact formats
- generate export files from background jobs
- reuse export behavior through DI in application services

[Back to top](#enumerableextensionsexporters)

---

<a id="espanol"></a>
# Español

[Ir a English](#english)

## Descripción general

`EnumerableExtensions.Exporters` proporciona métodos de extensión asíncronos para exportar cualquier `IEnumerable<T>` a disco en varios formatos.

Métodos de extensión disponibles:

- `ExportToJson`
- `ExportToCompressedJson`
- `ExportToMessagePack`

Puedes usarlos directamente o resolver el exportador mediante inyección de dependencias.

## Instalación

Agrega la referencia del paquete a tu proyecto:

```xml
<PackageReference Include="EnumerableExtensions.Exporters" Version="x.y.z" />
```

O referencia el proyecto directamente durante el desarrollo local.

## Namespace

```csharp
using EnunerableExtensions.Exporters.Extensions;
```

## Uso básico

```csharp
using EnunerableExtensions.Exporters.Extensions;

var people = new[]
{
    new Person(1, "Ada"),
    new Person(2, "Grace"),
    new Person(3, "Linus")
};

await people.ExportToJson("exports/people.json");
await people.ExportToCompressedJson("exports/people.json.gz");
await people.ExportToMessagePack("exports/people.mpack");

public sealed record Person(int Id, string Name);
```

## Uso con inyección de dependencias

Si ya usas `Microsoft.Extensions.DependencyInjection`, registra el servicio así:

```csharp
using EnunerableExtensions.Exporters.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddExporterService();

using var serviceProvider = services.BuildServiceProvider();

var people = new[]
{
    new Person(1, "Ada"),
    new Person(2, "Grace")
};

await people.ExportToJson("exports/people.json", serviceProvider);

public sealed record Person(int Id, string Name);
```

## Formatos de salida

### JSON
Crea un archivo JSON plano.

```csharp
await people.ExportToJson("exports/people.json");
```

### JSON comprimido
Crea un archivo JSON comprimido con GZip.

```csharp
await people.ExportToCompressedJson("exports/people.json.gz");
```

### MessagePack
Crea un archivo binario compacto usando MessagePack.

```csharp
await people.ExportToMessagePack("exports/people.mpack");
```

## Notas de comportamiento

- Todas las operaciones de exportación son asíncronas.
- Los directorios de destino se crean automáticamente cuando es necesario.
- `filePath` no puede ser nulo, vacío ni contener solo espacios.
- `data` no puede ser nulo.
- Si no se proporciona `IServiceProvider`, la librería usa su servicio exportador interno.

## Escenarios típicos

Esta librería es útil cuando necesitas:

- guardar resultados de consultas en disco
- archivar colecciones en formatos compactos
- generar archivos de exportación desde procesos en segundo plano
- reutilizar el comportamiento de exportación mediante DI en servicios de aplicación

[Volver arriba](#enumerableextensionsexporters)
