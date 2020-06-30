using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core
{
    public class RevisionTag : IEnumerable<int>
    {
        int[] path;

        public RevisionTag(int[] path)
        {
            this.path= path;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)path).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)path).GetEnumerator();
        }
    }
}
