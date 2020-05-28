using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
   
    public interface ILosObject 
    {
       
        TProperty Add<TProperty>(string propertyName);
        TProperty Add<TProperty>() => Add<TProperty>(typeof(TProperty).FullName);
        
        TProperty Add<TProperty>(Action<TProperty> initializer)  {
            var p = Add<TProperty>();
            initializer(p);
            return p;
        }

        object Get(string propertyName);
        TProperty Get<TProperty>(string propertyName) => (TProperty)Get(propertyName);
        TProperty Get<TProperty>() => Get<TProperty>(typeof(TProperty).FullName);

        object Remove(string propertyName);
        TProperty Remove<TProperty>(string propertyName) => (TProperty)Remove(propertyName);
        TProperty Remove<TProperty>() => Remove<TProperty>(typeof(TProperty).FullName);
    }

}
