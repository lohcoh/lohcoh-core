using Lohcode.eShopOnWeb.Presentation.Data;
using Lowkode.Client.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcode.eShopOnWeb.Presentation.Shared
{
    public partial class DisplayTable<TModel> : PlaceholderComponent<TModel>
    {
        [Parameter]
        public IReadOnlyList<TModel> Items { get; set; }

        public DisplayTable() { }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var partSpecification= new PartSpecification(typeof(TModel), null);
            var part= PartProvider.GetRequiredComponent(partSpecification);

        }
    }
}
