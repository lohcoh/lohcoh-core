using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
   
    public interface ILowKodeConfigurationService 
    {
        ILowKodeMetaRepository Repository { get; }
    }
}
