using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Components;
using LowKode.Core.LOS;
using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Components
{
    public class FindTypeDescriptor<TSystem> : IContextRequest<TypeDescriptor> 
    {
        public Type SystemType { get; }
        public FindTypeDescriptor()
        {
            SystemType= typeof(TSystem);
        }
    }
    public class FindTypeDescriptorHandler : IContextHandler<FindTypeDescriptor>
    {
        public Type Handle(FindTypeDescriptor request, CancellationToken cancellationToken)
        {
            var typeDescriptors= Scope.GetContext<TypeDescriptorCollection>();
            return typeDescriptors.Where(o => o.SystemType == request.SystemType).First();
        }
    }
    static public class FindTypeDescriptorExtension
    {
        public static Type FindTypeDescriptor(this Scope scope, Type systemType)
        {
            return scope.Accept(new FindTypeDescriptor(systemType));
        }
        public static Type FindTypeDescriptor<TSystem>(this Scope scope)
        {
            return FindTypeDescriptor(scope, typeof(TSystem));
        }
    }
}
