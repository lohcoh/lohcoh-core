using Lowkode.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcode.eShopOnWeb.Presentation.Shared
{
    public class DisplayTablePartSpecification : PartSpecification
    {
        public DisplayTablePartSpecification(Type componentType, IModelBinding modelBinding) 
            : base(componentType, modelBinding)
        {
        }
    }
}
