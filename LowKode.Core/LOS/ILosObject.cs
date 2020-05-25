using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.LOS
{
    public interface ILosObject<TObject>
    {
        ILosObject<TProperty> Add<TProperty>();
        ILosObject<TProperty> Get<TProperty>();
        ILosObject<TProperty> Remove<TProperty>();
    }
}
