using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lowkode.Client.Core
{
    /// <summary>
    /// Provides UI templates for a specific model part.
    /// The associated model part could be a Type, a property, an attribute, a parameter, etc.
    /// </summary>
    public interface IModelTemplateProvider : IPartProvider
    {

        /// <summary>
        /// Returns a template that display the name of the model part.
        /// </summary>
        /// <returns></returns>
        RenderFragment GetNameTemplate();


        /// <summary>
        /// Creates a template for the given view model.
        /// The view model can be a scalar value.
        /// </summary>
        RenderFragment GetTemplateFor(object viewModel);

    }
}
