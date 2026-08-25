using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Utils
{
    public static class Util
    {
        public static DateOnly ConverterData(int valor)
        {
            return DateOnly.FromDateTime(
                new DateTime(1800, 12, 28).AddDays(valor)
            );
        }
    }
}