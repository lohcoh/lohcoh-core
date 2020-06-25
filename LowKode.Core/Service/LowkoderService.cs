using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Configuration
{
   
    public class LowkoderService : ILowkoderService
    {
        public LosObjectSystem los { get; } = new LosObjectSystem();

        Stack<ComponentSite> sites = new Stack<ComponentSite>();

        public LowkoderService()
        {
            los.Master.Put(new LowkoderRoot());
            sites.Push(new ComponentSite(this, los.Master));
        }


        /// <summary>
        /// Creates a new site for rendering metadata-driven content.
        /// </summary>
        public IComponentSite RenderWithSite()
           => sites.Peek().Branch();        

       
    }
}
