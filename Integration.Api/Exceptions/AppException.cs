using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string msg) : base(msg)
        {
            
        }
    }
}