using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;

namespace LowKode.Core.Configuration
{
   
    public interface ILowkoderService 
    {
      
        public IComponentSite RenderWithSite();
    }
}
