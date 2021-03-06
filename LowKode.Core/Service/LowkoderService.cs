﻿using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using LowKode.Core.Service;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Configuration
{
   
    public class LowkoderService : ILowkoderService
    {
        public LosObjectSystem los { get; } = new LosObjectSystem();

        BlazorInterOp blazorInterOp = new BlazorInterOp();

        public LowkoderService()
        {
            los.Master.Put(new LowkoderRoot());
        }

        /*


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

        /// <summary>
        /// Create and returns a new branch of the given site.
        /// </summary>
        public IComponentSite CreateSite(IComponentSite site)
            => ((ComponentSite)site).Branch();
        */

        /// <summary>
        /// Create and returns a new branch of the component's parent site.
        /// </summary>
        public IComponentSite CreateSite(ComponentBase component)
        {
            var scope = blazorInterOp.FindFirstAncestor<Scope>(component);
            if (scope != null)
            {
                return ((ComponentSite)scope.Site).Branch();
            }

            /*
             * If no ancestor scope was found then the calling scope is an entry scope.
             */
            return new ComponentSite(this, los.Master);
        }
    }

}
