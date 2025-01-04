using Lucide.Blazor.Generator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lucide.Blazor.Extensions
{
    public static class IconExtension
    {
#if NET6_0
        public static IServiceCollection AddLucideIcons(this IServiceCollection services, string UrlIcons)
        {
            IconSets.Initialize(services.BuildServiceProvider().GetRequiredService<HttpClient>(), UrlIcons);
            return services;
        }
#elif NET7_0
       public static IServiceCollection AddLucideIcons(this IServiceCollection services, [StringSyntax(StringSyntaxAttribute.Uri)] string UrlIcons)
        {
            IconSets.Initialize(services.BuildServiceProvider().GetRequiredService<HttpClient>(), UrlIcons);
            return services;
        }
#elif NET8_0
       public static IServiceCollection AddLucideIcons(this IServiceCollection services, [StringSyntax(StringSyntaxAttribute.Uri)] string UrlIcons)
        {
            IconSets.Initialize(services.BuildServiceProvider().GetRequiredService<HttpClient>(), UrlIcons);
            return services;
        }
#endif

    }
}
