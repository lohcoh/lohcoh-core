

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Lohcode.eShopOnWeb.Presentation.Shared
{
    public partial class ElementFor<TOptions> : ComponentBase
        where TOptions: SiteOptions
    {
        private bool collapseNavMenu = true;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        public ElementFor()
        {
        }

        object _value= null;
        [Parameter] public object value { 
            get=>_value; 
            set {
                _value= value;
            }
        }

        TOptions _options = default(TOptions);
        [Parameter]
        public TOptions options
        {
            get => _options;
            set
            {
                _options = value;
            }
        }

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }
}