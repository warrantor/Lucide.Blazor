
# Lucide.Blazor


[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

Lucide.Blazor es una biblioteca que integra la poderosa colección de íconos de Lucide, diseñada originalmente para React, en aplicaciones Blazor. Esta implementación permite a los desarrolladores Blazor utilizar íconos SVG modernos, ligeros y completamente personalizables con características como tamaños ajustables, colores dinámicos, clases CSS y más. Perfecto para aplicaciones Blazor Server y Blazor WebAssembly.

Con Lucide.Blazor, puedes enriquecer tu interfaz de usuario con íconos atractivos, al tiempo que aprovechas la flexibilidad y simplicidad de Blazor.



## Inicializacion de servicio

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

## Uso componente Blazor

```blazor
@page "/"

<Icons Name="x" Width="10" Height="10" />

```
