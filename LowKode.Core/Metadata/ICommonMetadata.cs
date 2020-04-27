using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    public interface ICommonMetadata
    {
        string DisplayName { get;  }

        ComponentBase InputComponent { get; }
    }
}
