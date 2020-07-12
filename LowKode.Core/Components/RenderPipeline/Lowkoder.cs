using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LowKode.Core.Components
{

    /// <summary>
    /// Renders child content using Lowkoder's 'render pipeline'.
    /// </summary>
    public class Lowkoder : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        RenderFragment translatedChildContent;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            translatedChildContent = RenderFragmentTranslator.Translate( ChildContent);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            translatedChildContent(builder);
        }

    }
}
