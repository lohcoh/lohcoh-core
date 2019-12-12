using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    /// <summary>
    /// A part specification represents an instance of a placeholder element.
    /// A part specification is a collection of key:value pairs that are used to map a placeholder 
    /// component to a component implementation.
    /// Consider this Razor template...
    /// 
    ///     <EmailInput bindTo=@Binding<Customer>().Property(c=>c.Email) required/>
    ///     
    /// ... where Binding is a method provided lowkode components for binding components to model parts.
    /// 
    /// A specification could be built to represent this component like so...
    ///     var spec= new EmailInputPartSpecification() {
    ///         BoundTo= component.boundTo,
    ///         ComponentType= typeof(EmailInput),
    ///         Required = true
    ///     }
    ///     
    /// Every placeholder component knows how to create it's part specification.
    /// On the client, lowkode provides a global ImplementationProvider service.
    /// A placeholder component get's it's replacement by creating a new scope and then 
    /// calling implProvider.GetImplementation(partSpecification);
    /// Dispose of the scope when the placeholder is destroyed.
    /// 
    /// On the client, lowkode provides a global MetadataProvider service.
    /// class ImplementationProvider  {
    ///     public ComponentBase GetImplementation(partSpecification) {
    ///         var implDescription= metaService.GetData<IImplementationDescription>(partSpecification);
    ///         services.RegisterScoped(implDescription.BuildSpecification);
    ///         return services.GetRequiredService(implDescription.ImplementationType)
    ///     }
    /// }
    /// 
    /// Now, the magical part is how the build specification got built.
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
        public PartSpecification(PlaceholderComponent placeholderComponent, Type componentType, IModelBinding modelBinding)
        {
            this.PlaceholderComponent = placeholderComponent;
            this.ModelBinding = modelBinding;
            this.ComponentType = componentType;
        }

        /// <summary>
        /// The placeholder where the part will be inserted
        /// </summary>
        public PlaceholderComponent PlaceholderComponent { get; set; }

        /// <summary>
        /// The Type of the view model to be displayed by this element.
        /// The UI element associated with these options will be configured to accomodate the view model.
        /// For instance, if the associated UI element is a form then fields will be added to the form 
        /// for each property on the view model.
        /// </summary>
        public IModelBinding ModelBinding { get; }

        /// <summary>
        /// The Type of the component to be displayed.
        /// This is the Type of the associated lowcode component.
        /// </summary>
        public Type ComponentType { get; }
    }


}
