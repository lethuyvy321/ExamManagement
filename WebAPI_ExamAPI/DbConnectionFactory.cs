using System.Data;
using System.Data.SqlClient;
using WebAPI_ExamAPI.DBFactory;

namespace WebAPI_ExamAPI
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public DbConnectionFactory(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ConnectionDBString")!;
        }
        public IDbConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
