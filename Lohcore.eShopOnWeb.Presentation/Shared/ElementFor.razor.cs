

using Lowkode.Client.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Lohcode.eShopOnWeb.Presentation.Shared
{
    public partial class ElementFor<TComponent, TModel> : ComponentBase
    {
        private bool collapseNavMenu = true;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        public ElementFor()
        {
        }

        public PartSpecification PartSpecification {  get; }

        object _value= null;
        [Parameter] public IModelBinding ModelBinding { get; set; }

        bool? _options;
        [Parameter]
        public bool? required {  get; set; }

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }
}