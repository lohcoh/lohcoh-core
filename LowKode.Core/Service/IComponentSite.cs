using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components
{
    /// <summary>
    /// A service for providing and consuming context data.
    /// Context data is indexed by type, similar to cascading parameters.
    /// </summary>
    public interface IComponentSite :IDisposable
    {
        /// <summary>
        /// Get context data
        /// </summary>
        TContext Get<TContext>();

        /// <summary>
        /// Replaces any existing instance with the given instance
        /// </summary>
        void Insert<TContext>(TContext value);

        /// <summary>
        /// Updates any existing instance with values from the given value
        /// </summary>
        void Update<TContext>(TContext value);

        /// <summary>
        /// Returns a service that uses the current context data to generate a result.
        /// </summary>
        TService GetService<TService>() where TService:IContextService;
        void AddService<TService>(TService service) where TService : IContextService;
    }
}
