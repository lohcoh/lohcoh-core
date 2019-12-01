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
    public interface ILcModule
    {
        IReadOnlyList<LcModule> DependsOn { get; }
        bool IsStarted { get; }
    }
}
