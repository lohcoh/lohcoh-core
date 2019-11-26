using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcoh.Core.MetaObjects
{
    public class MetaObject : Dictionary<string, object>
    {

    }


    public class IMetaProperty<TValue>
    {

    }

    /**
     * Like in RDF, or JSON Linked Data, a metadata object is just a collection of properties, indexed by prperty id.
     */
    public interface IMetaObject
    {
        IReadOnlyDictionary<string, object> Properties {  get; }

        public TTypedMetaObject As<TTypedMetaObject>()
        {
            TTypedMetaObject v= null;
            return v;
        }
    }

    public interface IEntityMetadata : IMetaObject
    {
        public Type Type {  get; }
    }
}
