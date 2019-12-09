

using Lowkode.Client.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    /// <summary>
    /// Base class for all 'implementation' components.
    public class PartComponent<TModel> : ComponentBase
    {
        public virtual PlaceholderComponent PlaceholderComponent { get; set; }

        public RenderFragment ToRenderFragment()
        {
            return (RenderTreeBuilder builder) =>
            {
                this.BuildRenderTree(builder);
            };
        }
    }
}