using Lohcoh.Core.Startup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core
{
    /// <summary>
    /// Base class for all modules
    /// </summary>
    abstract public class LcModule : ILcModule
    {
        public IReadOnlyList<LcModule> DependsOn {  get; internal set; }
        public bool IsStarted { get; private set; } = false;

        /// <summary>
        /// This method is first invoked on the topmost application module, which will first 
        /// start all it's dependencies.
        /// Theoretically, the OnStart method should be first called for the LcCoreModule instance.
        /// </summary>
        internal void Start()
        {
            if (IsStarted)
                return;

            foreach (var dependent in DependsOn)
            {
                dependent.Start();
            }

            OnStart();

            IsStarted = true;
        }

        virtual protected void OnStart()
        {

        }
    }
}
