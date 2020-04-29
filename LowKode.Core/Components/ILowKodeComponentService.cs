using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LowKode.Core.Metadata
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
        /// Creates a component that is a subclass of the type denoted by TSlot, 
        /// suitable for editing or displaying the denoted property of the denoted type.
        /// </summary>
        ComponentBase Create<TSlot>(Type modelType, PropertyInfo property);
    }
}
