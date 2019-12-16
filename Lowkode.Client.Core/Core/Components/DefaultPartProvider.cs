using System;
using System.Threading.Tasks;
using Lowkode.Client.Core.Core.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Lowkode.Client.Core
{
    public class DefaultPartProvider : IPartProvider
    {
        public Task<RenderFragment> GetPartTemplate(PartSpecification partSpecification)
        {
            RenderFragment renderFragment = (RenderTreeBuilder builder) =>
            {
                /**
                 * TODO: Lookup the part type from the LowkodeExplorer.
                 * Part components will be conatined in library assemblies.
                 * These library assemblies will register thier parts with the LowkodeExplorer at startup.
                 */
                Type partType= typeof(DefaultPartComponent<>).MakeGenericType(partSpecification.ModelBinding.ModelType);

                builder.OpenComponent(0, partType);
                builder.AddAttribute(1, "PlaceholderComponent", partSpecification.PlaceholderComponent);
                builder.CloseComponent();
            };
            return Task.FromResult(renderFragment);
        }
    }
}
