using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Lowkode.Client.Core.Core.Repository
{
    public class OpenApiProviderFromFile : IOpenApiProvider
    {

        public string Path {  get; private set; }
        public OpenApiProviderFromFile(string path)
        {
            this.Path= path;
        }

        /// <summary>
        /// Blazor WebAssembly won't be ready for a while, so this method assumes we're using Blazor Server.  
        /// So a .json file is read.  
        /// For Blazer WA this should make an http call.
        /// </summary>
        /// <returns></returns>
        public Task<OpenApiDocument> GetDocument()
        {
            OpenApiDiagnostic apiDiagnostic= null;

            // Note: OpenApi.NET doesn't appear to have an async reader or I would have used it.
            OpenApiDocument document= 
                new OpenApiStreamReader().Read(new FileStream(Path, FileMode.Open), out apiDiagnostic);

            return Task.FromResult(document);
        }
    }
}
