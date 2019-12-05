namespace Lohcode.DDD
{
    /// <summary>
    /// An Aggregate Root is a tree of associated Entities.
    /// </summary>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    { }
}
