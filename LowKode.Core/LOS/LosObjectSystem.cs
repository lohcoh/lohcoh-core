using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public class LosObjectSystem : ILosObjectSystem
    {
        public ILosRoot Master { get; private set; }

        public LosObjectSystem()
        {
            Master = new LosRoot();
        }

    }
}
