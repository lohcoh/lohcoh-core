using System;

namespace LowKode.Core.LOS
{
    public interface Root
    {
        Root Branch(Action<object> p);

    }
}