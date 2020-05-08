using LowKode.Core.Context;
using System;
using System.Reflection;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Specifies all the information required to create a component.
    /// The IComponentSpecification interface only declares values that will be universally required to create a component.
    /// It's intended that there will be many implementations of this interface that require additional values.
    /// </summary>
    public class PropertyComponentSpec : ComponentSpecificationBase
    {
        public PropertyInfo Property { get; private set; }

    }
}
