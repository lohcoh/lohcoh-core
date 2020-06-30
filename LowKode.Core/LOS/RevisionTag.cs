using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LowKode.Core
{
    /// <summary>
    /// A RevisionTag is a sequence of branch indexes that identifies a value in a tree of values.
    /// A RevisionTag of zero length identifies the 'root' node.
    /// There is only on root node.
    /// A branch index, i, identifies the ith child of the parent node.
    /// </summary>
    public class RevisionTag : IEnumerable<int>
    {
        public static readonly RevisionTag ROOT = new RevisionTag(new int[0]);

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

        internal RevisionTag AddBranch(int nextBranch)
        {
            var newPath = new int[path.Length + 1];
            path.CopyTo(newPath, 0);
            newPath[path.Length] = nextBranch;
            return new RevisionTag(newPath);
        }
    }
}
