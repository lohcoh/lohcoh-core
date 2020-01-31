using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    /// <summary>
    /// A part specification represents an instance of a placeholder element.
    /// A part specification is a collection of key:value pairs that are used to map a placeholder 
    /// component to a part component (A concrete implementation of a placeholder component).
    /// Consider this Razor template...
    /// 
    ///     <EmailInput bindTo=@Binding<Customer>(c=>c.Email) required/>
    ///     
    /// ... where Binding is a method provided by the base placeholder component for binding components to model parts.
    /// 
    /// Here's a specification to represent this component...
    ///     var spec= new EmailInputPartSpecification() {
    ///         ModelBinding= component.bindTo,
    ///         ComponentType= typeof(EmailInput)
    ///     }
    ///     
    /// </summary>
    public class PartSpecification
    {
        /// <summary>
        /// A part specification is a collection of key:value pairs where the keys are 
        /// 
        /// The core lowkode components are place-holders for UI parts that are created at runtime.
        /// A placeholder component gives the UI engine a 'specification' of the part that it needs and 
        /// the engine returns a part that fulfills the specification.
        /// 
        /// The specification 
        /// 
        /// The most basic parts of a specification are...
        /// 
        /// - The view model.  What kind of object does the part display?
        /// 
        ///     The ModelType property denotes the kind of object displayed by the part
        ///     
        /// - What kind of UI elememnt is needed?
        /// 
        ///     User interface elements usually fall into one of the following four categories:
        ///     - Input Controls
        ///     - Navigation Components
        ///     - Informational Components
        ///     - Containers
        ///     
        ///     The ElementType property denotes the element type.
        /// 
        /// 
        ///     The same object can be displayed many different ways.
        ///     For instance, a Cusomter can be displayed in a grid, in a form, in a card.
        ///     Each display is different.
        ///     A lowkode component type demotes the kind of part needed.
        ///     For instance, <DisplayTable> denotes a grid-like component, a <Card> denotes an abbreviated, non-editable view of an object, etc.
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="modelType"></param>
        public PartSpecification(PlaceholderComponent placeholderComponent, IModelBinding modelBinding)
        {
            this.PlaceholderComponent = placeholderComponent;
            this.ModelBinding = modelBinding;
        }

        /// <summary>
        /// The placeholder where the part will be inserted
        /// </summary>
        public PlaceholderComponent PlaceholderComponent { get; set; }

        /// <summary>
        /// The data item(s) to be displayed by the part.
        /// </summary>
        public IModelBinding ModelBinding { get; }
    }


}
