using System.Data;
using Dapper;
using UsersAPI.Models;

namespace UsersAPI.Database.Repository;

public class UserRepository : IUserRepository
{
    private readonly DapperFactory _factory;

    public UserRepository(DapperFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        const string query = "SELECT * FROM users ";

        using IDbConnection connection = _factory.CreateConnection();

        var users = await connection.QueryAsync<User>(query).ConfigureAwait(false);

        return users;
    }

    public async Task<User?> GetUser(int id)
    {
        const string query = "SELECT * FROM users WHERE id = @Id";

        using IDbConnection connection = _factory.CreateConnection();

        User? user = await connection.QuerySingleOrDefaultAsync<User>(query, new {Id = id}).ConfigureAwait(false);

        return user;
    }

    public async Task<int> CreateUser(User user)
    {
        const string query = @"INSERT INTO users (firstname, lastname, age) VALUES (@FirstName, @LastName, @Age);
                               SELECT  CAST(LAST_INSERT_ID() as SIGNED); 
        ";

        using IDbConnection connection = _factory.CreateConnection();

        int id = await connection.QuerySingleAsync<int>(query, user).ConfigureAwait(false);

        return id;
    }

    public async Task UpdateUser(User user)
    {
        const string query = "UPDATE users SET firstname = @FirstName, lastname = @LastName, age = @Age WHERE id = @Id";

        using IDbConnection connection = _factory.CreateConnection();

        await connection.ExecuteAsync(query, user).ConfigureAwait(false);
    }

    public async Task DeleteUser(int id)
    {
        const string query = "DELETE FROM users WHERE id = @Id";

        using IDbConnection connection = _factory.CreateConnection();

        await connection.ExecuteAsync(query, new {id}).ConfigureAwait(false);
    }
}