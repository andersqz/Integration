using System.Data;

namespace Integration.Infra.Data
{
    public interface IDbConnectionFactory
    {

        Task<IDbConnection> CreateConnection();
    }
}