using Lohcode.eShopOnWeb.Presentation.Core.Parts;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    public class DefaultPartProvider : IPartProvider
    {
        public Task<ComponentBase> GetRequiredComponent(PartSpecification partSpecification)
        {
            return Task.FromResult<ComponentBase>(new DefaultPartComponent());
        }
    }
}
