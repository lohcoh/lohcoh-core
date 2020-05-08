using System;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core.Metadata
{
    /// <summary>
    /// Adds methods to ILowKodeMetaService for contributing metadata.
    /// 'root types' are the Types that will be used to retrieve the contributed metadata.
    /// </summary>
    public interface ILowKodeMetaRepository : ILowKodeMetaService
    {

        /// <summary>
        /// Add a new 'root' object to the repository.
        /// </summary>
        ILowKodeMetaRepository AddMetadataRoot(Type rootType, object metadataRoot);
        ILowKodeMetaRepository AddMetadataRoot<TRoot>(TRoot metadataRoot) => AddMetadataRoot(typeof(TRoot), metadataRoot);
        ILowKodeMetaRepository AddMetadataRoot(object metadataRoot) => AddMetadataRoot(metadataRoot.GetType(), metadataRoot);

    }
}
