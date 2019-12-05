using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcode.DDD
{
    /// <summary>
    /// All application parts are implemented by other assemblies.
    /// The metamodel service keeps track of these parts by creating 'ModelParts' that reference 
    /// the implementation objects and keeping track of the ModelParts.
    /// 
    /// ModelParts also hold metadata about the associated implementation object.
    /// </summary>
    /// 
    /// <typeparam name="TInterface">
    ///     The 'I' interface implemented by the associated implementation object.
    /// </typeparam>
    public class ModelPart<TRole> : IModelPart
    {
        public ModelPart(TRole implementation)
        {
            Implementation = implementation;
        }
        public TRole Implementation {  get; }
    }
    public interface IModelPart { }
}
