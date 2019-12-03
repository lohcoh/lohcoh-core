using System;

namespace Lohcode.DDD
{
    /// <summary>
    /// Entity classes must be marked with this interface.
    /// 
    /// Entities are persistent and therefore have an Id.
    /// Repositories are used to create, update, delete, and query entities 
    /// in persistent storage.
    /// </summary>
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
