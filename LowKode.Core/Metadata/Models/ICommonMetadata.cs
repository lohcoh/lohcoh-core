using LowKode.Core.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
 //todo: implement dependency properties
    public interface ICommonMetadata : IDependencyObject
    {
        string DisplayName { get;  }

        /// <summary>
        /// The Type of component used to edit this resource
        /// </summary>
        Type EditorType { get; }

        /// <summary>
        /// The Type of component used to display this resource
        /// </summary>
        Type DisplayType { get; }
    }
}
