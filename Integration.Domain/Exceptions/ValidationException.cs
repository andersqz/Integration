using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string msg) : base(msg)
        {
            
        }
    }
}