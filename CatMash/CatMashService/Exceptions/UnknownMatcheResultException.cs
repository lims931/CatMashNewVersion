using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Exceptions
{
    public class UnknownMatcheResultException : Exception
    {
        public UnknownMatcheResultException()
    {
    }

    public UnknownMatcheResultException(string message)
        : base(message)
    {
    }

    public UnknownMatcheResultException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
}
