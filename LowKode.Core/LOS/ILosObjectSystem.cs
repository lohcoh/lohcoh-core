using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core
{
    /// <summary>
    /// The Lowkoder Object System(LOS) is an embedded object system designed to serve as a lightweight and extensible metadata repository.
    /// LOS enables users to create simple trees of metadata.
    /// LOS can create many branches, or versions, of it's object tree in a space efficient manner.
    /// Each branch can be initialized with new metadata.
    /// Metadata trees are customized using rules that conditionally mutate metadata 
    /// based metadata changes.
    /// 
    /// </summary>
    public interface ILosObjectSystem
    {
        /// <summary>
        /// Creates a new 'object', with Type valueType.
        /// Inserts the new object into the object with id == objectId as property propertyName.
        /// Returns the id of the new object
        /// </summary>
        int Insert(int objectId, int revision, string propertyName, Type valueType);
        object Get(int objectId, int revision, string propertyName);
        
        void Remove(int objectId, int revision, string propertyName);
        
    }
}
