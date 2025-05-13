
# Lucide.Blazor


[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

[English version below](#english-version)

Lucide.Blazor es una biblioteca que integra la poderosa colección de íconos de Lucide, diseñada originalmente para React, en aplicaciones Blazor. Esta implementación permite a los desarrolladores Blazor utilizar íconos SVG modernos, ligeros y completamente personalizables con características como tamaños ajustables, colores dinámicos, clases CSS y más. Perfecto para aplicaciones Blazor Server y Blazor WebAssembly.

Con Lucide.Blazor, puedes enriquecer tu interfaz de usuario con íconos atractivos, al tiempo que aprovechas la flexibilidad y simplicidad de Blazor.



### Inicializacion de servicio

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddLucideIcons("https://unpkg.com/lucide-static@latest/icons");

var host = builder.Build();
await host.RunAsync();

```

### Uso componente Blazor

```blazor
@page "/"

<Icons Name="x" Width="10" Height="10" />

```
## English version
Lucide.Blazor is a library that integrates the powerful Lucide icon collection, originally designed for React, into Blazor applications. This implementation allows Blazor developers to use modern, lightweight and fully customizable SVG icons with features such as adjustable sizes, dynamic colors, CSS classes and more. Perfect for Blazor Server and Blazor WebAssembly applications.

With Lucide.Blazor, you can enrich your user interface with attractive icons, while taking advantage of Blazor's flexibility and simplicity.

### Service initialization
```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddLucideIcons("https://unpkg.com/lucide-static@latest/icons");

var host = builder.Build();
await host.RunAsync();

```

### Usage

```blazor
@page "/"

<Icons Name="x" Width="10" Height="10" />

```