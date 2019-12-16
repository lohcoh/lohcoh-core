

using Lowkode.Client.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    /// <summary>
    /// Base class for all 'part' components.
    /// A part component is a concrete implementation of a placeholder component.
    /// When a part component is instantiated the component's PlaceholderComponent 
    /// property is set to a reference to the specific placeholder component that 
    /// it will replace.
    /// 
    /// Placeholder components are passed model object(s) and are wired to other components.
    /// Placeholder components serve as a kind proxy for the part component.
    /// Part components get the model object(s) it needs from the part component.
    /// Placeholder components must provide API for the part components to fire events.
    /// </summary>
    public class PartComponent : ComponentBase
    {
        public virtual PlaceholderComponent PlaceholderComponent { get; set; }
    }
}