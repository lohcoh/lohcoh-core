using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcode.eShopOnWeb.Presentation.Shared
{
    /// <summary>
    /// A specification 
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public class PartSpecification<TComponent, TModel>
    {        
        /// <summary>
        /// lowkode components are place-holders for UI parts that are created at runtime.
        /// A lowkode component gives the UI engine a 'specification' of the part that it needs and 
        /// the engine returns a part that fulfills the specification.
        /// The most basic parts of a specification are...
        /// - What kind of objects does the part display?
        ///     The ModelType property denotes the kind of object displayed by the part
        /// - What kind of part is needed?
        ///     The same object can be displayed many different ways.
        ///     For instance, a Cusomter can be displayed in a grid, in a form, in a card.
        ///     Each display is different.
        ///     A lowkode component type demotes the kind of part needed.
        ///     For instance, <DisplayTable> denotes a grid-like component, a <Card> denotes an abbreviated, non-editable view of an object, etc.
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="modelType"></param>
        public PartSpecification(TComponent componentType, TModel modelType)
        {
            this.ModelType = modelType;
            this.ComponentType = componentType;
        }

        /// <summary>
        /// The Type of the view model to be displayed by this element.
        /// The UI element associated with these options will be configured to accomodate the view model.
        /// For instance, if the associated UI element is a form then fields will be added to the form 
        /// for each property on the view model.
        /// </summary>
        public TModel ModelType { get; }

        /// <summary>
        /// The Type of the component to be displayed.
        /// This is the Type of the associated lowcode component.
        /// </summary>
        public TComponent ComponentType { get; }
    }


}
