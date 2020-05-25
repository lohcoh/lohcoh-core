using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public class LosObject : ILosObject<TProperty>
    {
        LosObject prototype;
        int revision;

        /// <summary>
        /// Create an object when adding a new child to another LosObject
        /// </summary>
        /// <param name="revision">0 for the root branch, > 0 otherwise</param>
        LosObject(int revision)
        {
            this.root= root;
        }
        /// <summary>
        /// Create a braan object when adding a new child to another LosObject
        /// </summary>
        /// <param name="revision">0 for the root branch, > 0 otherwise</param>
        LosObject(LosObject prototype, int revision)
        {
            this.root = root;
        }

        public int ObjectId { get => this.GetHashCode(); }

        public ILosObject Add<TProperty>() where TProperty : ILosObject
        {
            objectSystem.Add<TProperty>
        }

        public ILosObject Get<TProperty>() where TProperty : ILosObject
        {
            throw new NotImplementedException();
        }

        public ILosObject Remove<TProperty>() where TProperty : ILosObject
        {
            throw new NotImplementedException();
        }
    }
}
