using System.Threading.Tasks;
using Lowkode.Client.Core.Core;
using Lowkode.Client.Core.Core.Parts;

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
