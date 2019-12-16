

using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace Lowkode.Client.Core
{
    /// <summary>
    /// Loads the OpenAPI document used by LowKode 
    /// </summary>
    public interface IOpenApiProvider 
    {
        Task<OpenApiDocument> GetDocument();
    }
}
