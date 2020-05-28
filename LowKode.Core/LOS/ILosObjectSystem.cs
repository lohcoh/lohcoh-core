using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public interface ILosObjectSystem
    {
        /// <summary>
        /// The root object of the master branch of the system.
        /// </summary>
        ILosRoot Master { get; }
    }
}
