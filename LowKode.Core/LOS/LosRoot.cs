using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    class LosRoot : LosObject, ILosRoot
    {

        /// <summary>
        /// Create a proxy to object with id == objectId in the given revision of the given object system.
        /// </summary>
        public LosRoot(ILosObjectSystem los, int revision, int objectId) : base(los, revision, objectId)
        {
        }

        public ILosRoot Branch()
        {
            // todo
            throw new NotImplementedException();
        }
    }
}
