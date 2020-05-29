using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
   
    public interface ILosObject 
    {

        object Add(string propertyName, Type tProperty);
        TProperty Add<TProperty>(string propertyName) where TProperty : ILosObject => (TProperty)Add(propertyName, typeof(TProperty));
        TProperty Add<TProperty>() where TProperty : ILosObject => Add<TProperty>(typeof(TProperty).FullName);
        
        object Get(string propertyName);
        TProperty Get<TProperty>(string propertyName) where TProperty : ILosObject => (TProperty)Get(propertyName);
        TProperty Get<TProperty>() where TProperty : ILosObject => Get<TProperty>(typeof(TProperty).FullName);

        void Remove(string propertyName);
    }

}
