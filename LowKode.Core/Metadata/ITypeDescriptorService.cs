using LowKode.Core.Components;
using System;

namespace LowKode.Core.Metadata
{
    public interface ITypeDescriptorService : IContextService
    {
        public TypeDescriptor GetTypeDescriptor(Type systemType);
        public TypeDescriptor GetTypeDescriptor<TSystem>() => GetTypeDescriptor(typeof(TSystem));
    }
}