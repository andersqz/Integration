using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Data
{
    public interface IDbConnectionFactory
    {

        Task<IDbConnection> CreateConnection();
    }
}