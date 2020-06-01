namespace LowKode.Core.LOS
{
    /// <summary>
    /// The root of an object tree retrieved from a LOS object system.
    /// </summary>
    public interface ILosRoot : ILosObject
    {
        /// <summary>
        /// Saves the
        /// </summary>
        ILosRoot Save();
    }
}