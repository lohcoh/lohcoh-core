using LowKode.Core.Context;
using Microsoft.AspNetCore.Components;
using System;
using System.Reflection;

namespace LowKode.Core.Components
{

    /// <summary>
    /// Creates component instances based on settings contained in the ILowKodeMetaService and context 
    /// values in the ILowKodeContextService.
    /// 
    /// The ILowKodeComponentService is only responsible for creating the component, the 
    /// caller is responsible for wiring the component, ie, setting parameters and event handlers and such.
    /// 
    /// </summary>
    public interface ILowKodeComponentService 
    {
        /// <summary>
        /// Create a Component
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        ComponentBase Create(ILowKodeContext context);

       
    }
}
