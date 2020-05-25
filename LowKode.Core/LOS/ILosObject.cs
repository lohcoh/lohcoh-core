using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public interface ILosObject
    {

        ILosObject Add<TProperty>(string propertyName) where TProperty : ILosObject;

        ILosObject Add<TProperty>() where TProperty : ILosObject => Add<TProperty>(typeof(TProperty).Name);

        ILosObject Get<TProperty>(string propertyName) where TProperty : ILosObject;
        ILosObject Get<TProperty>() where TProperty : ILosObject => Get<TProperty>(typeof(TProperty).Name);

        ILosObject Remove<TProperty>(string propertyName) where TProperty : ILosObject;
        ILosObject Remove<TProperty>() where TProperty : ILosObject => Remove<TProperty>(typeof(TProperty).Name);
    }
}
