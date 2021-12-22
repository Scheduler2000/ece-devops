using System.Data;
using MySql.Data.MySqlClient;

namespace UsersAPI.Database;

public class DapperFactory
{
    private readonly IConfiguration _configuration;

    private readonly string _connectionString;

    public DapperFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = Environment.GetEnvironmentVariable("DB_URL") ?? configuration.GetConnectionString("MySqlConnection");
    }

    /// <summary>
    ///     This Constructor is for testing purpopses only.
    /// </summary>
    /// <param name="connectionString"></param>
    public DapperFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}