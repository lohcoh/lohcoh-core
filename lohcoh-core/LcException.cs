using System;
using System.Runtime.Serialization;

namespace Lohcoh.Core
{
    [Serializable]
    internal class LcException : Exception
    {
        public LcException()
        {
        }

        public LcException(string message) : base(message)
        {
        }

        public LcException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LcException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}