using MySql.Data.MySqlClient;

namespace OrderingSystemV1.Components.Database
{
    public class Database
    {
        private readonly string _connectionString;

        public Database (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
