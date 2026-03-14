# EnumerableExtensions.Exporters

Language / Idioma: [English](#english) | [Español](#espanol)

A small .NET library that adds extension methods to `IEnumerable<T>` so collections can be exported to JSON, compressed JSON, and MessagePack.

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

## Typical scenarios

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

About me ![](https://user-images.githubusercontent.com/18350557/176309783-0785949b-9127-417c-8b55-ab5a4333674e.gif)My name is José David Galviz Muñoz
===============================================================================================================================================

Entrepreneur, Software Architect, Frontend and Backend Developer and Much More!!!
---------------------------------------------------------------------------------

I started in the world of programming in 1992, since then it has been a journey full of many challenges and emotions.

* 🌍  I'm based in Barranquilla, Colombia.
* ✉️  You can contact me at [jose.david.galviz@gmail.com](mailto:jose.david.galviz@gmail.com)
* 🚀  I'm currently working on [Gasolutions](http://www.gasolutions.com.co/)
* 🤝  I'm open to collaborating on interesting projects open sources and commercials.
* ⚡  If you need me, email me!!!

### Skills


<p align="left">
<a href="https://docs.microsoft.com/en-us/dotnet/csharp/" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/csharp-colored.svg" width="36" height="36" alt="C#" /></a><a href="https://git-scm.com/" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/git-colored.svg" width="36" height="36" alt="Git" /></a><a href="https://code.visualstudio.com/" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/visualstudiocode.svg" width="36" height="36" alt="VS Code" /></a><a href="https://developer.mozilla.org/en-US/docs/Glossary/HTML5" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/html5-colored.svg" width="36" height="36" alt="HTML5" /></a><a href="https://jquery.com/" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/jquery-colored.svg" width="36" height="36" alt="JQuery" /></a><a href="https://mui.com/" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/materialui-colored.svg" width="36" height="36" alt="Material UI" /></a><a href="https://getbootstrap.com/" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/bootstrap-colored.svg" width="36" height="36" alt="Bootstrap" /></a><a href="https://www.adobe.com/uk/products/premiere.html" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/premierepro-colored.svg" width="36" height="36" alt="Premiere Pro" /></a><a href="https://wix.com" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/wix-colored.svg" width="36" height="36" alt="Wix" /></a><a href="https://dotnet.microsoft.com/en-us/" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/skills/dot-net-colored.svg" width="36" height="36" alt=".NET" /></a>
</p>


### Socials

<p align="left"> <a href="https://www.dev.to/jgalviz" target="_blank" rel="noreferrer"> <picture> <source media="(prefers-color-scheme: dark)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/devdotto-dark.svg" /> <source media="(prefers-color-scheme: light)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/devdotto.svg" /> <img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/devdotto.svg" width="32" height="32" /> </picture> </a> <a href="https://www.github.com/jgalviz1974" target="_blank" rel="noreferrer"> <picture> <source media="(prefers-color-scheme: dark)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/github-dark.svg" /> <source media="(prefers-color-scheme: light)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/github.svg" /> <img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/github.svg" width="32" height="32" /> </picture> </a> <a href="https://www.linkedin.com/in/jgalviz" target="_blank" rel="noreferrer"> <picture> <source media="(prefers-color-scheme: dark)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/linkedin-dark.svg" /> <source media="(prefers-color-scheme: light)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/linkedin.svg" /> <img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/linkedin.svg" width="32" height="32" /> </picture> </a> <a href="https://medium.com/@jgalviz_1568" target="_blank" rel="noreferrer"> <picture> <source media="(prefers-color-scheme: dark)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/medium-dark.svg" /> <source media="(prefers-color-scheme: light)" srcset="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/medium.svg" /> <img src="https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/medium.svg" width="32" height="32" /> </picture> </a></p>

### Badges

<b>My GitHub Stats</b>

<a href="http://www.github.com/jgalviz1974"><img src="https://github-readme-streak-stats.herokuapp.com/?user=jgalviz1974&stroke=ffffff&background=1c1917&ring=0891b2&fire=0891b2&currStreakNum=ffffff&currStreakLabel=0891b2&sideNums=ffffff&sideLabels=ffffff&dates=ffffff&hide_border=true" /></a>
