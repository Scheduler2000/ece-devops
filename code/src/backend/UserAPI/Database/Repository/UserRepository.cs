using System.Data;
using Dapper;
using UsersAPI.Models;

namespace UsersAPI.Database.Repository;

public class UserRepository : IUserRepository
{
    private readonly DapperFactory _factory;
    private readonly ILogger _logger;

    public UserRepository(DapperFactory factory, ILogger logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        const string query = "SELECT * FROM users ";

        using IDbConnection connection = _factory.CreateConnection();

        var users = await connection.QueryAsync<User>(query).ConfigureAwait(false);

        return users;
    }

    public async Task<User> GetUser(int id)
    {
        const string query = "SELECT * FROM users WHERE id = @Id";

        using IDbConnection connection = _factory.CreateConnection();

        User? user = await connection.QuerySingleOrDefaultAsync<User>(query, new {Id = id}).ConfigureAwait(false);

        return user;
    }

    public async Task CreateUser(User user)
    {
        const string query = "INSERT INTO users (first_name, last_name, age) VALUES (@FirstName, @LastName, @Age)";

        using IDbConnection connection = _factory.CreateConnection();

        await connection.ExecuteAsync(query, user).ConfigureAwait(false);
    }

    public async Task UpdateUser(User user)
    {
        const string query = "UPDATE users SET first_name = @FirstName, last_name = @LastName, age = @Age WHERE id = @Id";

        using IDbConnection connection = _factory.CreateConnection();

        await connection.ExecuteAsync(query, user);
    }

    public async Task DeleteUser(int id)
    {
        const string query = "DELETE FROM users WHERE id = @Id";

        using IDbConnection connection = _factory.CreateConnection();

        await connection.ExecuteAsync(query, new {id});
    }
}