using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public class LosObject : ILosObject
    {
        LosObject prototype;
        int revision;

        /// <summary>
        /// Create an object when adding a new child to another LosObject
        /// </summary>
        /// <param name="revision">0 for the root branch, > 0 otherwise</param>
        LosObject(int revision)
        {

        }
        /// <summary>
        /// Create a braan object when adding a new child to another LosObject
        /// </summary>
        /// <param name="revision">0 for the root branch, > 0 otherwise</param>
        LosObject(LosObject prototype, int revision)
        {

        }

        public int ObjectId { get => this.GetHashCode(); }

        public TProperty Add<TProperty>(string propertyName)
        {
            throw new NotImplementedException();
        }

        public object Get(string propertyName)
        {
            throw new NotImplementedException();
        }

        public object Remove(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
