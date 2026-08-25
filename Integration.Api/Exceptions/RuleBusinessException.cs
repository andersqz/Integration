using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Exceptions
{
    public class RuleBusinessException : Exception
    {
        public RuleBusinessException(string msg) : base(msg)
        {
            
        }
    }
}