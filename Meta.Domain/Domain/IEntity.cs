using System;

namespace Meta.Domain
{
    /// <summary>
    /// Entities are persistent and therefore have an Id.
    /// Repositories are used to create, update, delete, and query entities 
    /// in persistent storage.
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
