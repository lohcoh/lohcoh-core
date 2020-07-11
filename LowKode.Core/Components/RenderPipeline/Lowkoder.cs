using LowKode.Core.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{

    /// <summary>
    /// Renders child content using Lowkoder's 'render pipeline'.
    /// </summary>
    public class Lowkoder : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        Action<RenderTreeBuilder> translatedChildContent;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            translatedChildContent = new RenderFragmentTranslator().Translate(ChildContent);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            translatedChildContent(builder);
        }

    }
}
