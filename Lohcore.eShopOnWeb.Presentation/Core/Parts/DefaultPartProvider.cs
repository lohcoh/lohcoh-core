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
        public Task<PartComponent<TModel>> GetRequiredComponentAsync<TModel>(PartSpecification partSpecification)
        {
            var part = new DefaultPartComponent<TModel>();
            part.PlaceholderComponent = partSpecification.PlaceholderComponent;
            return Task.FromResult<PartComponent<TModel>>(part);
        }
    }
}
