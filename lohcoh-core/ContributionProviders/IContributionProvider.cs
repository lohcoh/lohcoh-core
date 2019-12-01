using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core.ContributionProviders
{
    public interface IContributionProvider
    {
        /// <summary>
        /// find the contributions embedded in the denoted module
        /// </summary>
        ICollection DiscoverContributions(ILcModule module);
    }
}
