using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Components.Forms
{
    public class EditFieldModel
    {
        public IPropertyMetadata Metadata { get; internal set; }
        public ComponentBase EditComponent { get; internal set; }
    }
}
