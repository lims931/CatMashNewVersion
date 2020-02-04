using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Exceptions
{
    public class DataBaseAccessException : Exception
    {
        public DataBaseAccessException()
        {
        }

        public DataBaseAccessException(string message)
            : base(message)
        {
        }

        public DataBaseAccessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
