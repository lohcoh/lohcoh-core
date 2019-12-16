using System;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;



namespace Lowkode.Client.Core
{
    /// <summary>
    /// A container for an OpenAPI document that contains all lowkode metadata.
    /// This class provides methods for querying the document for data.
    /// Creator components query the Lowkode API repository for metadata.
    /// 
    /// The results returned for a query don't depend solely on the given query 
    /// but also on the current scope.
    /// </summary>
    public class LowkodeExplorer : ILowkodeExplorer
    {
        Task<OpenApiDocument> openApiDocument;
        public LowkodeExplorer(IOpenApiProvider openApiProvider)
        {
            this.openApiDocument = openApiProvider.GetDocument();
        }

        TResult ILowkodeExplorer.Query<TResult>(Func<OpenApiDocument, TResult> query)
        {
            return query(openApiDocument.Result);
        }
    }
}
