namespace LowKode.Core
{
    /// <summary>
    /// The root of an object tree retrieved from a LOS object system.
    /// </summary>
    public interface ILosRoot : ILosObject
    {
        public int Revision { get; }

        /// <summary>
        /// Saves the
        /// </summary>
        ILosRoot Save();
    }
}