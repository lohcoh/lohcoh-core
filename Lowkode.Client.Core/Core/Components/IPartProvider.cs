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
        /// This method returns a RenderFragment that will render the content component denoted by the given content specification.
        /// </summary>
        Task<RenderFragment> GetPartTemplate(PartSpecification partSpecification);

    }
}
