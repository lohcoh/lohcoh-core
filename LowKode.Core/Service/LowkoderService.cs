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
        {
            var branch= sites.Peek().Branch();
            sites.Push(branch);
            return new SiteWrapper(this, branch);
        }

        internal void DisposeSite(ComponentSite site)
        {
            if (sites.Contains(site))
            {
                while (sites.Peek() != site)
                    sites.Pop();
                sites.Pop();
            }
            site.Dispose();
        }

        public IComponentSite CreateSite()
        {
            var branch = sites.Peek().Branch();
            return branch;
        }

        public IComponentSite RenderWithSite(IComponentSite site)
        {
            sites.Push((ComponentSite)site);
            return site;
        }

        public IComponentSite RenderWithBranch()
        {
            return RenderWithSite(sites.Peek().Branch());
        }
    }

    class SiteWrapper : IComponentSite
    {
        ComponentSite site;
        LowkoderService lowkoder;
        public SiteWrapper(LowkoderService lowkoder, ComponentSite site)
        {
            this.site = site;
            this.lowkoder = lowkoder;
        }

        public LowkoderContext Context => site.Context;

        public LowkoderMetadata Metadata => site.Metadata;

        public void Dispose()
        {
            lowkoder.DisposeSite(site);
        }
    }
}
