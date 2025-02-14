using Lucide.Blazor.Generator;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Lucide.Blazor.Components
{
    public class Icons : ComponentBase
    {
        /// <summary>
        /// Nombre del Icono
        /// </summary>
        [Parameter]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Clase css a utilizar
        /// </summary>
        [Parameter]
        public string? Css { get; set; }

        /// <summary>
        /// Ancho del icono 
        /// </summary>
        [Parameter]
        public string Width { get; set; } = "24";

        /// <summary>
        /// Alto del icono
        /// </summary>
        [Parameter]
        public string Height { get; set; } = "24";

        /// <summary>
        /// View box del icono
        /// </summary>
        [Parameter]
        public string ViewBox { get; set; } = "0 0 24 24";

        /// <summary>
        /// Fill del icono
        /// </summary>
        [Parameter]
        public string Fill { get; set; } = "none";

        [Parameter]
        public string Stroke { get; set; } = "currentColor";

        [Parameter]
        public string StrokeWidth { get; set; } = "2";

        [Parameter]
        public string StrokeLinecap { get; set; } = "round";

        [Parameter]
        public string StrokeLinejoin { get; set; } = "round";

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        private string? IconValue { get; set; }


        protected override async void OnParametersSet()
        {
            base.OnParametersSet();

            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException(nameof(Name));

            if (!string.IsNullOrWhiteSpace(Css))
            {
                Attributes["class"] = Css;
            }
            

            IconValue = await IconSets.GetIconsAsync(Name);

            StateHasChanged();
        }

        public RenderFragment RenderIcon => builder =>
        {
            
            if (string.IsNullOrWhiteSpace(Css))
            {
                builder.AddAttribute(2, "width", Width);
                builder.AddAttribute(3, "height", Height);
            }
            builder.AddAttribute(4, "viewBox", ViewBox);
            builder.AddAttribute(5, "fill", Fill);
            builder.AddAttribute(6, "stroke", Stroke);
            builder.AddAttribute(7, "stroke-width", StrokeWidth);
            builder.AddAttribute(8, "stroke-linecap", StrokeLinecap);
            builder.AddAttribute(9, "stroke-linejoin", StrokeLinejoin);

            if (Attributes?.Any() == true)
            {
                builder.AddMultipleAttributes(10, Attributes);
            }

            if (!string.IsNullOrEmpty(IconValue))
            {
                builder.AddMarkupContent(11, IconValue);
            }

            builder.CloseElement();
        };

        protected override async void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(1, RenderIcon);
        }
    }
}
