using System;
using System.Collections.Generic;
using System.Text;

namespace Lowkode.Client.Core
{
    public class DefaultModelBinding : IModelBinding
    {
        public DefaultModelBinding(Type ModelType, IModelPartSelector ModelPartSelector= null) 
        {  
            this.ModelType= ModelType;
            this.ModelPartSelector= ModelPartSelector;
        }

        public Type ModelType { get; set; }
        public IModelPartSelector ModelPartSelector { get; set; }
    }
}
