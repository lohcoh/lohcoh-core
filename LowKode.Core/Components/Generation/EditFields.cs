using LowKode.Core.Configuration;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Renders the properties of a form model.
    /// Can only be used with an <EditForm/> component.
    /// </summary>
    public class EditFields : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }


        [Parameter]
        public Type TModel { get; set; }


        [CascadingParameter]
        EditContext EditContext { get; set; }

        [Inject] ILowkoderService lowkoder { get; set; }

        public EditFields()
        {
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (EditContext == null)
            {
                throw new InvalidOperationException("No EditContext found");
            }

            if (TModel == null)
            {
                TModel = EditContext.Model.GetType();
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            using (var formSite = lowkoder.RenderWithSite())
            {
                TypeDescriptor modelMetadata = formSite.Metadata.ForSystemType(TModel);
                formSite.Context.ComponentSiteSpecification.Model = EditContext.Model;
                formSite.Context.ComponentSiteSpecification.ModelType = modelMetadata;

                foreach (var property in modelMetadata.Properties)
                {
                    using (var propertySite = lowkoder.RenderWithSite())
                    {
                        propertySite.Context.ComponentSiteSpecification.ModelMember = property.ToMemberPath();
                        builder.AddContent(0, ChildContent);
                    }
                }
            }
        }
    }
}
