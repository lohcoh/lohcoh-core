using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace Lowkode.Client.Core
{
    /// <summary>
    /// IModelMetadata a recursive, catch-all container for the metadata that lowkode uses.
    /// Every model part (Types, properties, Attributes, methods, parameters, etc) has an associated IModelMetadata object that 
    /// holds metadata about the part.
    /// Model metadata can be accessed via the ILowkodeExplorer service.
    /// </summary>
    public interface IModelMetadata 
    {

        /// <summary>
        /// All model objects have associated UI elements.
        /// The TemplateProvider provides access to Razor templates (RenderFragments) that can display the associated object.
        /// </summary>
        IModelTemplateProvider TemplateProvider { get; }


        /// <summary>
        /// If the associated model part has properties then this method return the metadata for the properties
        /// </summary>
        /// <returns></returns>
        ReadOnlyCollection<IModelMetadata> Properties { get; }

        /// <summary>
        /// If the associated model part is a property then this property returns the model property's getter method.
        /// </summary>
        PropertyInfo PropertyInfo { get; }

        /// <summary>
        /// If the associated model part is a property then this property returns the model property's getter method.
        /// </summary>
        Type ModelType { get; }
    }
}
