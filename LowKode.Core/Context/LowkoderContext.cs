using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace LowKode.Core
{
    /// <summary>
    /// The root node of the Lowkoder context system.
    /// </summary>
    public class LowkoderContext 
    {
        public virtual SiteSpecification SiteSpecification { get; } = new SiteSpecification();
    }
}
