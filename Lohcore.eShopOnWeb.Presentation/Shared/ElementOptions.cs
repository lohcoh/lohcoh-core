using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcode.eShopOnWeb.Presentation.Shared
{
    public class ElementOptions<TValue>
    {
        public Type ValueType { get=>typeof(TValue); }

        /// <summary>
        /// True if the associated UI element should allow editing
        /// </summary>
        public bool IsForEdit {  get; } = false; 

        public ElementOptions<TValue> ForEdit() {  return null; }
    }
}
