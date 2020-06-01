using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
   
    public interface ILosObject 
    {

        public void Add(string propertyName, Type typeOfValue, object value);
        public void Add<TProperty>(string propertyName, TProperty value) where TProperty : class, new() 
            => Add(propertyName, typeof(TProperty), value);
        public void Add<TProperty>(TProperty value) where TProperty : class, new() 
            => Add<TProperty>(typeof(TProperty).FullName, value);

        public object Get(string propertyName);
        public TProperty Get<TProperty>(string propertyName) where TProperty : class, new()
            => (TProperty)Get(propertyName);
        public TProperty Get<TProperty>() where TProperty : class, new()
            => Get<TProperty>(typeof(TProperty).FullName);

        public void Remove(string propertyName);
    }

}
