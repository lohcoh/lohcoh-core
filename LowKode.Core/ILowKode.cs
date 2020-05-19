using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.Metadata;
using LowKode.Core.Context;

namespace LowKode.Core
{
    /// <summary>
    /// One-stop shopping for components, aggregates references to the LK Meta, Component, and Context services.
    /// </summary>
    public interface ILowKode
    {
        ILowKodeComponentService Components { get; }
        ILowKodeMetadata Metadata { get; }
        IContext Context { get; }
    }
}
