using LowKode.Core.Components;
using LowKode.Core.Metadata;

namespace LowKode.Core
{
    /// <summary>
    /// One-stop shopping for components, aggregates references to the LK Meta, Component, and Context services.
    /// </summary>
    public interface ILowKode
    {
        ILowKodeComponentService Components { get; }
        LowkoderMetadata Metadata { get; }
        LowkoderContext Context { get; }
    }
}
