using System;
using System.Collections;
using System.Collections.Generic;

namespace Lohcoh.Core
{
    public interface ILcRegistry
    {

        /// <summary>
        /// Find all metadata contributions of the denoted type
        /// </summary>
        /// <typeparam name="TContribution">the type of metadata contribution</typeparam>
        public ICollection<TContribution> Contributions<TContribution>();
    }
}