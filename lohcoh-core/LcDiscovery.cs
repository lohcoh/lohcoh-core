using Lohcoh.Core.ContributionProviders;
using System;

namespace Lohcoh.Core
{
    public class LcDiscovery
    {
        ILcRegistry lcRegistry;
        public LcDiscovery(ILcRegistry lcRegistry)
        {
            this.lcRegistry= lcRegistry;
        }

        /// <summary>
        /// Execute all contribution providers and populate the given registry
        /// </summary>
        internal void DoDiscovery()
        {
            // todo - service providers should also be discovered.
            new AttributeContributionProvider(lcRegistry).DoDiscovery();
        }
    }
}