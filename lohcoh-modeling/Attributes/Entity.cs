﻿using System;

namespace Lohcoh.Modeling
{
    /// <summary>
    /// The Entity attribute will cause lohcoh to create add the associated class to 
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class)]
    [MetadataSource] 
    public class Entity : Attribute
    {
    }
}
