using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Exceptions
{
    public class InvalidMatchParametersException : Exception
    {
        public InvalidMatchParametersException()
        {
        }

        public InvalidMatchParametersException(string message)
            : base(message)
        {
        }

        public InvalidMatchParametersException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
