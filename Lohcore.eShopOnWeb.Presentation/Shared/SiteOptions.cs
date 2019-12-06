using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcode.eShopOnWeb.Presentation.Shared
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public class SiteOptions<TView, TModel>
    {
        
        public SiteOptions(Type siteType, Type modelType)
        {
            this.ForModelType = modelType;
        }

        /// <summary>
        /// The Type of the view model to be displayed by this element.
        /// The UI element associated with these options will be configured to accomodate the view model.
        /// For instance, if the associated UI element is a form then fields will be added to the form 
        /// for each property on the view model.
        /// </summary>
        public Type ForModelType { get; }

        /// <summary>
        /// The Type of the view model to be displayed by this element.
        /// The UI element associated with these options will be configured to accomodate the view model.
        /// For instance, if the associated UI element is a form then fields will be added to the form 
        /// for each property on the view model.
        /// </summary>
        public Type ForComponentType { get; }

        /// <summary>
        /// True if the associated UI element should allow editing.
        /// </summary>
        public bool IsForEdit {  get; } = false; 
    }


}
