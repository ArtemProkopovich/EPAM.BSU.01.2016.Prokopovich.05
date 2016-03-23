using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace Task1.Exceptions
{
    public class StorageIOException : IOException
    {
        public StorageIOException()
        {
        }

        public StorageIOException(string message) : base(message)
        {
        }

        public StorageIOException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public StorageIOException(string message, int hresult) : base(message, hresult)
        {
        }

        protected StorageIOException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
