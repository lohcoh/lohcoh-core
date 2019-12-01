using System;
using System.Collections.Generic;

namespace Lohcoh.Core
{
    public interface ILcModuleManifest
    {
        public IReadOnlyCollection<Type> DependsOn { get; }
        public IReadOnlyCollection<Type> Provides { get; }
    }
}