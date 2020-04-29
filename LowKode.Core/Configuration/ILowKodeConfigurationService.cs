using System;
using System.Collections.Generic;
using System.Text;
using LowKode.Core.Metadata;

namespace LowKode.Core.Configuration
{
   
    public interface ILowKodeConfigurationService 
    {
        ILowKodeMetaRepository Repository { get; }
    }
}
