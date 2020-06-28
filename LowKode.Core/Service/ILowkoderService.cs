using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Configuration
{
   
    public interface ILowkoderService 
    {
      
        //public IComponentSite RenderWithSite();
        /// <summary>
        /// Creates a new site that is a branch of the given site
        /// </summary>
        //IComponentSite CreateSite(IComponentSite site);

        /// <summary>
        /// Creates a new site that is a branch of the site associated with the given component's enclosing scope.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        IComponentSite CreateSite(ComponentBase component);

    }
}
