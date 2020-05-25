using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    class LosObjectProxy<TProperty> : ILosObject<TProperty>
    {
        public ILosObject<TProperty1> Add<TProperty1>()
        {
            throw new NotImplementedException();
        }

        public ILosObject<TProperty1> Get<TProperty1>()
        {
            throw new NotImplementedException();
        }

        public ILosObject<TProperty1> Remove<TProperty1>()
        {
            throw new NotImplementedException();
        }
    }
}
