using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcoh.Core
{

    /// <summary>
    /// Module for the Lohcoh Core module
    /// </summary>
    [Module]
    [Provides(typeof(LcRegistry), InterfaceType=typeof(ILcRegistry))]
    public class LcCoreModule : LcModule
    {
        internal ICollection<LcModule> AllModules { get; set; }

        internal ILcRegistry Registry;

        public LcCoreModule(ILcRegistry registry)
        {
            this.Registry= registry;
        }

        protected override void OnStart()
        {
            new LcDiscovery(Registry).DoDiscovery();
        }
    }

}
