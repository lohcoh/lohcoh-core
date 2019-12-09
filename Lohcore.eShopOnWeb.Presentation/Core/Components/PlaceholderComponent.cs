

using Lowkode.Client.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    public abstract class PlaceholderComponent : ComponentBase
    {

    }

    /// <summary>
    /// Base class for all 'placeholder' components.
    /// The primary purpose of this component is to provide the parameters and other API 
    /// that most placeholder components require to make modeling as easy as possible.
    /// </summary>
    /// <typeparam name="TModel">
    ///     Every placeholder component must be bound to an object to display.
    ///     TModel denotes the type of the object to display.
    ///     TModel plays a primary role in determiing what a component displays.
    /// </typeparam>
    public class PlaceholderComponent<TModel> : PlaceholderComponent
    {
        bool? _required;

        public PartSpecification PartSpecification {  get; }

        object _value= null;
        [Parameter] 
        public IModelBinding ModelBinding { get; set; }

        [Parameter]
        public bool? required {  get; set; }


    }
}