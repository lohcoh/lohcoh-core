using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core.ContributionProviders
{
    public class AttributeContributionProvider
    {
        private ILcRegistry lcRegistry;
        public AttributeContributionProvider(ILcRegistry lcRegistry)
        {
            this.lcRegistry= lcRegistry;
        }
        internal void DoDiscovery()
        {
            
        }
    }
}
