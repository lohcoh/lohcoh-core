using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    public interface IPartProvider
    {
        /// <summary>
        /// Creates a UI component from the given part specification.
        /// 
        /// </summary>
        /// <param name="partSpecification"></param>
        /// <returns></returns>
        Task<PartComponent<TModel>> GetRequiredComponentAsync<TModel>(PartSpecification partSpecification);
    }
}
