using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Common.DependentObjects
{
    /// <summary>
    /// lowkoder's dependent object API is like a standalone object system with it's own 
    /// special behavior above and beyond what's possible with native c#/.NET.
    /// This class implements the core semantics of dependent objects in lowkoder.
    /// 
    /// History:  WPF used dependent objects as a way of tracking objects, saving memory, 
    /// and dynamically applying properties to components and XAML tags.
    /// Lowkoder uses dynamic object for the same reasons but with one very important 
    /// addition... dynamic objects in lowkoder are prototype-based.
    /// That is, every object has a prototype and object inherits properties and 
    /// methods from it's prototype.
    /// This functionality is the heart of lowkoder's context and metadata systems.
    /// 
    /// </summary>
    public class DependendentObjectSystem
    {
    }
}
