﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashService.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException()
        {
        }

        public ElementNotFoundException(string message)
            : base(message)
        {
        }

        public ElementNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
