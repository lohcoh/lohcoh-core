﻿using LowKode.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core
{
    public class LowkoderRoot
    {
        public virtual LowkoderContext Context { get; set; } = new LowkoderContext();
        public virtual LowkoderMetadata Metadata { get; set; } = new LowkoderMetadata();
    }
}
