using LowKode.Core.Metadata;
using Microsoft.AspNetCore.Components;

namespace LowKode.Core.Components
{
    public class EditFieldModel
    {
        public IPropertyMetadata Metadata { get; internal set; }
        public ComponentBase EditComponent { get; internal set; }
    }
}
