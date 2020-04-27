using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    public class CommonMetadata : ICommonMetadata
    {

        public string DisplayName { get; set;  }
        public ComponentBase InputComponent { get; set; }

    }
}
