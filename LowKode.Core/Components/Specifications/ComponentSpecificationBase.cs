using LowKode.Core.Context;
using System;

namespace LowKode.Core.Components
{
    /// <summary>
    /// Specifies all the information required to create a component.
    /// The IComponentSpecification interface only declares values that will be universally required to create a component.
    /// It's intended that there will be many implementations of this interface that require additional values.
    /// </summary>
    public class ComponentSpecificationBase : IComponentSpecification
    {
        public Type ComponentType => throw new NotImplementedException();

        public object Value => throw new NotImplementedException();

        public Type ModelType => throw new NotImplementedException();

        public ILowKodeContext Context => throw new NotImplementedException();
    }
}
