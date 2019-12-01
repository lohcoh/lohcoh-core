using System;
using System.Collections.Generic;
using System.Text;

namespace Lohcoh.Core
{
    /// <summary>
    /// Identifies a class as a logcoh module
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleAttribute : Attribute
    {
        public Type[] DependsOn { get; set; }


  //      @NgModule({
  //      declarations: [AppComponent],
  //imports: [BrowserModule],
  //providers: [],
  //bootstrap: [AppComponent]
  //      })
    }
}
