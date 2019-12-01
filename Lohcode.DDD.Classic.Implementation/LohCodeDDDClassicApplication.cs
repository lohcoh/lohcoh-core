using System.Collections.Generic;
using System.Threading.Tasks;
using Meta.Domain;

namespace Lohcode.DDD.Classic.Implementation
{
    public class LohCodeDDDClassicApplication : IApplication
    {
        private List<IApplicationService> _services= new List<IApplicationService>();
        public IReadOnlyCollection<IApplicationService> Services { get => _services; }

        public void AddService(IApplicationService applicationService)
        {
            if (!_services.Contains(applicationService))
                _services.Add(applicationService);
        }
    }
}