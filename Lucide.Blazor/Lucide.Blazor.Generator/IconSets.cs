using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Lucide.Blazor.Generator
{
    public static class IconSets
    {
        private static readonly ConcurrentDictionary<string, string> Icons = new();
        private static string UrlIcons = string.Empty;
        private static HttpClient _httpClient;

        // <summary>
        /// Inicializa el HttpClient y la URL base para los íconos.
        /// </summary>
        /// <param name="httpClient">Instancia de HttpClient.</param>
        /// <param name="urlIcons">URL base de los íconos.</param>
        public static void Initialize(HttpClient httpClient, string urlIcons)
        {
            _httpClient = httpClient;
            UrlIcons = urlIcons;
        }

        /// <summary>
        /// Obtenemos el LucideIcon por su nombre.
        /// </summary>
        /// <param name="iconName">Nombre del Icono</param>
        /// <returns>El path svg del icon</returns>
        public static async Task<string> GetIconsAsync(string iconName)
        {
            if (Icons.TryGetValue(iconName, out var compressedSvg))
            {
                return compressedSvg;
            }

            try
            {
                var url = $"{UrlIcons}/{iconName}.svg";
                compressedSvg = await _httpClient.GetStringAsync($"{UrlIcons}/{iconName}.svg");
                
                var svg = XDocument.Parse(compressedSvg);

                var elements = svg.Root.Descendants()
                    .Select(element =>
                    {
                        element.Name = element.Name.LocalName;
                        return element.ToString(SaveOptions.DisableFormatting);
                    });


                var paths = string.Concat(elements);
                Icons[iconName] = paths;

                return paths;
            }
            catch (HttpRequestException)
            {
                throw new FileNotFoundException($"El ícono '{iconName}' no se encontró en la ruta '{UrlIcons}'.");
            }
        }
    }
}
