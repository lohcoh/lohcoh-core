using Castle.DynamicProxy;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LowKode.Core.LOS
{

    /// <summary>
    /// 
    /// LosObjectAdapter is a proxy that represents objects outside of the LOS object system.
    /// That is, LOS presents a object-oriented API to it's users, but internally LOS saves 
    /// it's data in tables and such.  So, when the user selects data from a LOS object system 
    /// a proxy is created by LOS that the user can use to access that object's data.
    /// 
    /// A LOS proxy also tracks changes in order to efficiently saved a mutated object tree to a new branch in LOS.
    /// 
    /// Castle.Core.DictionaryAdapter is used to adapt LosObjectAdapter to a specific Type interface.
    /// Property get/sets on the Type are translated by Castle into Dictionary methods calls.
    /// LosObjectAdapter translates gets into calls to a LOS object system to fetch the associated data.
    /// LosObjectAdapter tracks sets, when the associated object tree is saved property changes are persisted to 
    /// the object system.
    /// 
    /// </summary>
    class LosObjectAdapter : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.
        }
    }
}
