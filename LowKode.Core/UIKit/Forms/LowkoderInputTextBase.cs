using LowKode.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Displays the model in a non-editable way.
    /// </summary>
    public class LowkoderInputTextBase : Input
    {
        public LowkoderInputTextBase(IComponentSite site) : base(site) { }


        object Model;
        MemberPath MemberPath;

        public string modelValue
        {
            get { return (string)MemberPath.Get(Model); }
            set { MemberPath.Set(Model, value); }
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            Model = site.Context.ComponentSiteSpecification.Model;
            MemberPath = site.Context.ComponentSiteSpecification.ModelMember;

        }
    }
}
