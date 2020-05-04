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
        /// Creates a component that is a subclass of componentType, 
        /// suitable for editing or displaying the denoted property of the denoted model type.
        /// </summary>
        /// <param name="componentType">The type denoting the slot type, usually LowKode.Core.Components.Editor or usually LowKode.Core.Components.Display </param>
        ComponentBase Create(Type componentType, Type modelType, IMetaSelector property);

        /// <summary>
        /// Creates a component that is a subclass of the type denoted by TSlot, 
        /// suitable for editing or displaying a value of the given type.
        /// </summary>
        /// <typeparam name="TSlot">The type denoting the slot type, usually LowKode.Core.Components.Editor or usually LowKode.Core.Components.Display </typeparam>
        ComponentBase Create<TSlot>();
    }
}
