#pragma checksum "C:\Users\zen\source\repos\lohcoh-core\Lowkoder.Tests.Fixtures\BasicInputSiteExample.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d718f81d2bca4d32105e92c2f5b75fb295aea5a1"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace LowKode.Tests.Fixtures
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\zen\source\repos\lohcoh-core\Lowkoder.Tests.Fixtures\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\zen\source\repos\lohcoh-core\Lowkoder.Tests.Fixtures\BasicInputSiteExample.razor"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zen\source\repos\lohcoh-core\Lowkoder.Tests.Fixtures\BasicInputSiteExample.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\zen\source\repos\lohcoh-core\Lowkoder.Tests.Fixtures\BasicInputSiteExample.razor"
using LowKode.Core.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\zen\source\repos\lohcoh-core\Lowkoder.Tests.Fixtures\BasicInputSiteExample.razor"
using Microsoft.AspNetCore.Components.Rendering;

#line default
#line hidden
#nullable disable
    public partial class BasicInputSiteExample : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "C:\Users\zen\source\repos\lohcoh-core\Lowkoder.Tests.Fixtures\BasicInputSiteExample.razor"
       
    SiteSpecification SiteSpecification= new SiteSpecification()
    {
        ModelType = typeof(string),
        Model = "Hello World"
    }
    private string _starship = "Starship()";

    private void HandleValidSubmit()
    {
        Console.WriteLine("OnValidSubmit");
    }

    string Hello { get; set; } = "$$$ from Lowkoder";



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
