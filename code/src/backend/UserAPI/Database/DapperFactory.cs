using System.Data;
using MySql.Data.MySqlClient;

namespace UsersAPI.Database;

public class DapperFactory
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    
    private readonly string _connectionString;

    public DapperFactory(IConfiguration configuration, ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySqlConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
    
}